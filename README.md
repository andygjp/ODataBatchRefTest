# README

A small sample project to test referencing new entities created as part of an odata batch request.

This is what I should be able to do: [OData JSON Format Version 4.01 - 19.2 Referencing New Entities](https://docs.oasis-open.org/odata/odata-json-format/v4.01/odata-json-format-v4.01.html#sec_ReferencingNewEntities)

# Instructions

Build and run the project. With Jetbrains Rider or VSCode with the [Rest Client plugin](https://marketplace.visualstudio.com/items?itemName=humao.rest-client), you can execute each request in the `tests.http` file. The last request, "batch create contact and get the newly created contact", fails - it returns a 500 instead of a 200. The issue has been reported here: https://github.com/OData/AspNetCoreOData/issues/360
