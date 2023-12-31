﻿using iShipping.Ly.Application.Constants;
using iShipping.Ly.Application.Dtos;
using iShipping.Ly.Application.Dtos.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace iShipping.Ly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result.Item2);
        }

        [HttpPost]
        [Route("RegisterAccount")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest request)
        {
            var result = await _mediator.Send(request);

            if (result.Succeeded)
            {
                return Ok($"تمت اضافة {request.FirstName} {request.LastName} بنجاح");
            }

            return BadRequest(result.Errors);
        }

        [HttpPost]
        [Route("RegisterAdminAccount")]
        //[Authorize(Roles = nameof(Roles.SuperAdmin))]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAdminAsync([FromBody] CreateAdminRequest request)
        {
            var result = await _mediator.Send(request);

            if (result.Succeeded)
            {
                return Ok($"تمت اضافة {request.FirstName} {request.LastName} بنجاح");
            }

            return BadRequest(result.Errors);
        }

        [HttpPut("UpdateUserProfile/{userId}")]
        public async Task<IActionResult> UpdateUserProfileAsync([FromBody] UpdateUserProfileRequest request, string? userId)
        {
            string id = string.Empty;

            if (User.IsInRole(nameof(Roles.SuperAdmin)))
            {
                id = userId!;
            }
            else
            {
                id = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            }

            if (id == null)
            {
                return Problem("المستخدم غير موجود");
            }

            var result = await _mediator.Send(new UpdateUserProfileRequest
                (Id: id,
                UserName: request.UserName,
                Email: request.Email,
                PhoneNumber: request.PhoneNumber,
                FirstName: request.FirstName,
                LastName: request.LastName,
                IdentificationCardNumber: request.IdentificationCardNumber,
                ProfilePicture: request.ProfilePicture));

            if (result.Succeeded)
            {
                return Ok("تم تعديل بيانات المستخدم بنجاح");
            }

            return BadRequest(result.Errors);
        }

        [HttpPost]
        [Route("RemoveAccount")]
        //[Authorize(Roles = nameof(Roles.SuperAdmin))]
        [AllowAnonymous]
        public async Task<IActionResult> RemoveAsync([FromBody] DeleteUserRequest request)
        {
            var result = await _mediator.Send(request);

            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok("تم حذف حساب المستخدم بنجاح");
        }

        [HttpGet("GetUser/{userId}")]
        //[Authorize(Roles = nameof(Roles.SuperAdmin))]
        [AllowAnonymous]
        public async Task<ActionResult<GetUsersResponse>> GetUserAsync(string userId)
            => Ok(await _mediator.Send(new GetUserRequest(userId: userId)));

        [HttpGet("GetUsers")]
        //[Authorize(Roles = nameof(Roles.SuperAdmin))]
        [AllowAnonymous]
        public async Task<ActionResult<Response<GetUsersResponse>>> GetUsersAsync([FromQuery] GetUsersRequest request)
            => Ok(await _mediator.Send(request));

        [HttpGet("SearchUsers")]
        //[Authorize(Roles = nameof(Roles.SuperAdmin))]
        [AllowAnonymous]
        public async Task<ActionResult<Response<GetUsersResponse>>> SearchUsersAsync([FromQuery] SearchUsersRequest request)
            => Ok(await _mediator.Send(request));

        [HttpPost("ChangePassword/{userId}")]
        public async Task<ActionResult> ChangePasswordAsync([FromBody] ChangePasswordRequest request, string? userId)
        {
            string id = string.Empty;

            if (User.IsInRole(nameof(Roles.SuperAdmin)))
            {
                id = userId!;
            }
            else
            {
                id = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            }

            if (id == null)
            {
                return Problem("المستخدم غير موجود");
            }

            var result = await _mediator.Send(new ChangePasswordRequest(
                Id: id,
                OldPassword: request.OldPassword,
                NewPassword: request.NewPassword,
                ConfirmPassword: request.NewPassword));

            if (result.Succeeded)
            {
                return Ok("تم تغيير كلمة المرور بنجاح");
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("ResetPassword")]
        //[Authorize(Roles = nameof(Roles.SuperAdmin))]
        [AllowAnonymous]
        public async Task<ActionResult> ResetPasswordAsync([FromBody] ResetPasswordRequest request)
        {
            var result = await _mediator.Send(request);

            if (result.Succeeded)
            {
                return Ok("تمت تغيير كلمة المرور بنجاح");
            }

            return BadRequest(result.Errors);
        }
    }

}
