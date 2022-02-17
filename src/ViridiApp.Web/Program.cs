using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using ViridiApp.Data;
using ViridiApp.Domain.Repositories;
using ViridiApp.Data.Repositories;
using ViridiApp.Application.Interfaces;
using ViridiApp.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<ViridiContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("ViridiContext"),
        assembly => assembly.MigrationsAssembly("ViridiApp.Data")
    )
);

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IIssueRepository, IssueRepository>();

// Add Application Layer
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IIssueService, IssueService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
