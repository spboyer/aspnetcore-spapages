# Angular SPA Template w/ ASP.NET Core Razor Pages

** Uses .NET Core 2.0 Preview 2 **

# Benchmark

## MVC Controllers (.NET Core SDK 1.1.2)

```bash
# debug
$ dotnet run
Time to start-up, retrieve home page, and shutdown: 00:00:38.2724292

# release
$ dotnet run -c Release
Time to start-up, retrieve home page, and shutdown: 00:00:36.4821101

# using console util "time"
$ time dotnet run -c Release

Time to start-up, retrieve home page, and shutdown: 00:00:38.6843646
dotnet run -c Release  5.39s user 1.43s system 15% cpu 43.556 total
```

## SPA Pages (.NET Core SDK 2.0.0-preview2-006349)

```bash
# debug
$ dotnet run
Time to start-up, retrieve home page, and shutdown: 00:00:24.5998130

# Publish app and webpack with prod flag
$ dotnet publish -c Release
# Run with release configuration
$ dotnet run -c Release

Time to start-up, retrieve home page, and shutdown: 00:00:22.5516450

# using console util "time"
$ time dotnet run -c Release

Time to start-up, retrieve home page, and shutdown: 00:00:23.6450260
dotnet run -c Release  6.86s user 1.60s system 21% cpu 25.736 total
```