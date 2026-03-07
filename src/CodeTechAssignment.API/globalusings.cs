global using System.Net;
global using System.Text.Json;
global using Microsoft.AspNetCore.Mvc;
global using Serilog;

// Global usings for the API project to reduce boilerplate in individual files
global using CodeTechAssignment.Application;
global using CodeTechAssignment.DTO;
global using CodeTechAssignment.Persistence.Oracle;
global using CodeTechAssignment.Persistence.Postgres;
global using CodeTechAssignment.Persistence.SqlServer;
global using CodeTechAssignment.Middleware;
global using CodeTechAssignment.Services;
