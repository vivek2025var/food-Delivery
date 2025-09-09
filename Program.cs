using FoodDeliveryAPI.Hubs;
using FoodDeliveryAPI.Repositories;
using FoodDeliveryAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add Controllers + Authorization
builder.Services.AddControllers();
builder.Services.AddAuthorization();

// SignalR
builder.Services.AddSignalR();

// ================= Repositories & Services =================

// User
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

// Repository registration
builder.Services.AddScoped<IMenuItemResponseRepository,MenuItemResponseRepository>();

// Service registration
builder.Services.AddScoped<IMenuItemResponseService, MenuItemResponseService>();

// Rider
builder.Services.AddScoped<IRiderRepository, RiderRepository>();
builder.Services.AddScoped<IRiderService, RiderService>();

// Restaurant
builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();

// MenuCategory
builder.Services.AddScoped<IMenuCategoryRepository, MenuCategoryRepository>();
builder.Services.AddScoped<IMenuCategoryService, MenuCategoryService>();

// MenuItem
builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();
builder.Services.AddScoped<IMenuItemService, MenuItemService>();

// Cart
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICartService, CartService>();

// CartItem
builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
builder.Services.AddScoped<ICartItemService, CartItemService>();

// Order
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

// OrderItem
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();

// Notification
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddHostedService<DailyNotificationService>();

// ============================================================

var app = builder.Build();

// Middleware
app.UseAuthorization();

// Endpoints
app.MapControllers();
app.MapHub<NotificationHub>("/notificationhub");

app.Run();
