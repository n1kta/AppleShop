using AppleShop.Payment.API.Consumers;
using AppleShop.Payment.API.RabbitMQSender;
using PaymentProcessor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IProcessorPayment, ProcessorPayment>();
builder.Services.AddSingleton<IMessageSender, RabbitMQPaymentMessageSender>();
builder.Services.AddHostedService<RabbitMQConsumer>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
