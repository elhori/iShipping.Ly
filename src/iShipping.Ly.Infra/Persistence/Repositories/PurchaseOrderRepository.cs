using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos;
using iShipping.Ly.Application.Dtos.PurchaseOrder;
using iShipping.Ly.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace iShipping.Ly.Infra.Persistence.Repositories
{
    public class PurchaseOrderRepository : AsyncRepository<PurchaseOrder>, IPurchaseOrderRepository
    {
        private readonly DataContext _context;

        public PurchaseOrderRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<PurchaseOrder> GetAsync(int id, CancellationToken cancellationToken = default)
            => await _context.PurchaseOrders.Include(i => i.Items).FirstAsync(i => i.Id == id);

        public async Task<Response<GetPurchaseOrdersResponse>> GetResponseAsync(GetPurchaseOrdersRequest request, CancellationToken cancellationToken = default)
        {
            var data = _context.PurchaseOrders
                .Include(p => p.Items)
                .Join(_context.Users, po => po.CustomerId, u => u.Id, (po, u) => new { PurchaseOrder = po, User = u })
                .AsNoTracking();

            var skip = request.PageSize * (request.CurrentPage - 1);

            var totalResults = await data.CountAsync(cancellationToken);

            var results = await data
                .OrderBy(i => i.PurchaseOrder.Id)
                .Skip(skip)
                .Take(request.PageSize)
                .Select(i => new GetPurchaseOrdersResponse
                {
                    Id = i.PurchaseOrder.Id,
                    OrderPrice = i.PurchaseOrder.OrderPrice,
                    Status = i.PurchaseOrder.Status,
                    CustomerId = i.PurchaseOrder.CustomerId,
                    CustomerName = $"{i.User.FirstName} {i.User.LastName}",
                    Items = i.PurchaseOrder.Items.Select(item => new GetPurchaseOrderItemsResponse
                    {
                        Id = item.Id,
                        ProductLink = item.ProductLink,
                        ColorAndSize = item.ColorAndSize,
                        Note = item.Note,
                        Price = item.Price,
                        Quantity = item.Quantity,
                        ShippingPriceInDollar = item.ShippingPriceInDollar,
                        TotalPrice = item.TotalPrice,
                        TrackingNumber = item.TrackingNumber
                    }).ToList()

                }).ToListAsync(cancellationToken);

            return new Response<GetPurchaseOrdersResponse>
            {
                CurrentPage = request.CurrentPage,
                PageSize = request.PageSize,
                TotalResults = totalResults,
                Results = results
            };
        }

        public async Task<Response<GetPurchaseOrdersResponse>> GetResponseAsync(GetCustomerPurchaseOrdersRequest request, CancellationToken cancellationToken = default)
        {
            var data = _context.PurchaseOrders
                .Where(i => i.CustomerId == request.CustomerId)
                .Include(p => p.Items)
                .Join(_context.Users, po => po.CustomerId, u => u.Id, (po, u) => new { PurchaseOrder = po, User = u })
                .AsNoTracking();

            var skip = request.PageSize * (request.CurrentPage - 1);

            var totalResults = await data.CountAsync(cancellationToken);

            var results = await data
                .OrderBy(i => i.PurchaseOrder.Id)
                .Skip(skip)
                .Take(request.PageSize)
                .Select(i => new GetPurchaseOrdersResponse
                {
                    Id = i.PurchaseOrder.Id,
                    OrderPrice = i.PurchaseOrder.OrderPrice,
                    Status = i.PurchaseOrder.Status,
                    CustomerId = i.PurchaseOrder.CustomerId,
                    CustomerName = $"{i.User.FirstName} {i.User.LastName}",
                    Items = i.PurchaseOrder.Items.Select(item => new GetPurchaseOrderItemsResponse
                    {
                        Id = item.Id,
                        ProductLink = item.ProductLink,
                        ColorAndSize = item.ColorAndSize,
                        Note = item.Note,
                        Price = item.Price,
                        Quantity = item.Quantity,
                        ShippingPriceInDollar = item.ShippingPriceInDollar,
                        TotalPrice = item.TotalPrice,
                        TrackingNumber = item.TrackingNumber
                    }).ToList()

                }).ToListAsync(cancellationToken);

            return new Response<GetPurchaseOrdersResponse>
            {
                CurrentPage = request.CurrentPage,
                PageSize = request.PageSize,
                TotalResults = totalResults,
                Results = results
            };
        }
    }
}
