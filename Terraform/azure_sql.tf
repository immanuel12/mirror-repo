resource "azurerm_mssql_server" "server_dev" {
  name                         = "sql-${var.project_name}"
  resource_group_name          = azurerm_resource_group.rg.name
  location                     = azurerm_resource_group.rg.location
  version                      = "12.0"
  administrator_login          = "sqladmin"
  administrator_login_password = "P@ssw0rd123!"

  # tags = merge(
  #   {"Environment" = "${var.environments}"},
  #   {"BillingItem" = "Azure SQL Server"}
  # )
}

resource "azurerm_mssql_database" "db_dev" {
  name           = "db-${var.project_name}"
  server_id      = azurerm_mssql_server.server_dev.id
  collation      = "SQL_Latin1_General_CP1_CI_AS"
  max_size_gb    = 256
  read_scale     = false
  min_capacity   = 1
  sku_name       = "GP_S_Gen5_4"
  zone_redundant = false
  storage_account_type = "Local"
  auto_pause_delay_in_minutes = -1

  # tags = merge(
  #   {"Environment" = "${var.environments}"},
  #   {"BillingItem" = "Azure SQL Database"}
  # )

  # #prevent the possibility of accidental data loss
  # lifecycle {
  #   prevent_destroy = true
  # }
}

# resource "azurerm_private_endpoint" "pe_sql_dev" {

#   name                = "pe-sql-${var.project_name}-${var.environment}"
#   location            = azurerm_resource_group.rg.location
#   resource_group_name = azurerm_resource_group.rg.name
#   subnet_id           = module.virtual_network.subnet_ids[4]

#   private_service_connection {
#     name                           = "ip-pe-sql-${var.project_name}-${var.environment}"
#     is_manual_connection           = false
#     private_connection_resource_id = azurerm_mssql_server.server_dev.id
#     subresource_names              = ["sqlServer"]  
#   }

#   tags = merge(
#     {"Environment" = "${var.environments}"},
#     {"BillingItem" = "Azure SQL Database"}
#   )  
# }