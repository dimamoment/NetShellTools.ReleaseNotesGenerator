Automated Release Notes Generator

A microservices-based application designed to automate the creation of release notes based on Azure DevOps ticket data. The application has three independent microservices, which can also operate independetly:

- API Gateway - an entry point, routing requests to other microservices.

- PTS (Project Tracking System) - integrates with Azure DevOps to retrieve ticket(user stories, tasks, bugs and etc.) information. Users provide a ticket IDs, and PTS returns detailed ticket data.

- OpenAI Service - leverages the OpenAI API to generate release notes based on the data provided by the PTS service.
