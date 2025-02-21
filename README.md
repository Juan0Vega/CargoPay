#CargoPay
API para la creación de tarjetas y gestión de pagos.

🚀 Descripción
CargoPay es una API desarrollada en .NET que permite la gestión de tarjetas y pagos. Ofrece funcionalidades para:

📌 Crear tarjetas con un cupo o saldo inicial.
💰 Consultar el saldo o cupo de una tarjeta.
🔄 Generar transacciones, aplicando tarifas o impuestos dinámicos.
El endpoint de generación de transacciones utiliza un ciclo de vida Singleton, lo que garantiza que solo haya una instancia activa. Además, la tarifa aplicada a cada transacción cambia cada minuto antes de descontarse del saldo de la tarjeta.

Las entidades Tarjeta y Pagos están relacionadas, permitiendo un historial de transacciones por tarjeta.

🛠 Tecnologías utilizadas
Lenguaje: C# .NET
Base de datos: SQL Server
ORM: Entity Framework
Autenticación: JWT
