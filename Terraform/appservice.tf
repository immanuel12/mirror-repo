resource "azurerm_app_service_plan" "app_service_plan" {
  name                = "appserviceplan-${var.project_name}"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name

  sku {
    tier = "Standard"
    size = "S1"
  }
}

resource "azurerm_app_service" "app_service" {
  name                = "appservice-${var.project_name}"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  app_service_plan_id = azurerm_app_service_plan.app_service_plan.id
  client_affinity_enabled = true
  https_only = true

  site_config {
    always_on = true
    default_documents        = ["Default.htm","Default.html","Default.asp","index.htm","index.html","iisstart.htm","default.aspx","index.php","hostingstart.html",]
    dotnet_framework_version = "v6.0"
    scm_type                 = "None"
    use_32_bit_worker_process = true
  }

#   connection_string {
#     name  = "Database"
#     type  = "SQLServer"
#     value = "Server=sql-devsecops.database.windows.net;Database=db-devsecops;User ID=sqladmin;Password=P@ssw0rd123!;Encrypt=true;TrustServerCertificate=false;Connection Timeout=30;"
#   }
}