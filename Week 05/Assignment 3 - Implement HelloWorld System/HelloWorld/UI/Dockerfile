# Step 1: Build the Blazor WebAssembly app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["UI/UI.csproj", "UI/"]
RUN dotnet restore "UI/UI.csproj"

# Copy the rest of the source code
COPY . . 
WORKDIR "/src/UI"

# Publish the Blazor WebAssembly app for release
RUN dotnet publish "UI.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Step 2: Serve the app with Nginx
FROM nginx:alpine AS final

# Copy the published app to Nginx's public directory
COPY --from=build /app/publish/wwwroot /usr/share/nginx/html

# Expose the port that Nginx will serve on
EXPOSE 80

# Start Nginx to serve the app
CMD ["nginx", "-g", "daemon off;"]
