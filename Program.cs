using FoodDeliveryAPI.Repositories;
using FoodDeliveryAPI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthorization(); //
builder.Services.AddControllers(); //
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
//Rider
builder.Services.AddScoped<IRiderRepository, RiderRepository>();
builder.Services.AddScoped<IRiderService,RiderService>();

//Restraunt
builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();

//MenuCategory
builder.Services.AddScoped<IMenuCategoryRepository, MenuCategoryRepository>();
builder.Services.AddScoped<IMenuCategoryService, MenuCategoryService>();

//MenuItem
builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();
builder.Services.AddScoped<IMenuItemService, MenuItemService>();

//Cart 

builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICartService, CartService>();

//CartItem
builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
builder.Services.AddScoped<ICartItemService, CartItemService>();

//Order
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

//OrderItem
builder.Services.AddScoped<IOrderItemRepository,OrderItemRepository>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();


var app = builder.Build();
app.UseAuthorization();
app.MapControllers();
app.Run();
