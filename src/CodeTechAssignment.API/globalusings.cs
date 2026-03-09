global using System.Net;
global using System.Text.Json;
global using Microsoft.AspNetCore.Mvc;
global using FluentValidation;
global using FluentValidation.AspNetCore;
global using Serilog;

// Global usings for the API project to reduce boilerplate in individual files
global using CodeTechAssignment.DTO;
global using CodeTechAssignment.Application;
global using CodeTechAssignment.Infrastructure;
global using CodeTechAssignment.Middleware;
global using CodeTechAssignment.Persistence.Oracle;
global using CodeTechAssignment.Persistence.Postgres;
global using CodeTechAssignment.Persistence.SqlServer;