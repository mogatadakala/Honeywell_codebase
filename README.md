# Stadium Analytics API

A production-style Event Driven Architecture solution built using:

- .NET 8 Web API
- SQL Server
- Entity Framework Core
- AutoMapper
- Data Annotations Validation
- Background Services
- Swagger/OpenAPI
- Default Microsoft Logging

This application simulates stadium gate sensor events and provides analytics summaries for dashboard reporting.

---

# Problem Statement

Mr. Green owns a large stadium and requires a dashboard to monitor:

- Number of people entering gates
- Number of people exiting gates
- Analytics over a period of time

Each gate contains sensors that generate events asynchronously.

Example event:

```json
{
  "gate": "Gate A",
  "timestamp": "2023-04-01T08:00:00Z",
  "numberOfPeople": 10,
  "type": "enter"
}
