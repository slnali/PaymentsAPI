# Assumptions made

- Basic CRUD API, didn't stretch too far with enforcing CRUD for persistence as it would require more "Boilerplate" code
- Create Payment sends response to Merchant to confirm that payment was created, have not hidden card details here though

# Technologies used

- Language: C# Framework: .NET 5
- Packages: EF Core, xUnit, Swashbuckle

# Future improvements

- Currently just created a quick in memory data store, for production of course data should be persisted to backend database
- Given that data might be queried in across a range of columns perhaps SQL database would be best
- DI Container for handling dependencies e.g. using framework like Lamar
- Enforce some data validation checks at the model level but controller should perhaps contain a validation checker to make sure the payment is valid
- Unit tests at controller level for higher level functional/integration tests of below components and lower level at unit for repositories
- Could have had nested models for User details & Card details in the payments model to further define purpose of data
- Use SpecFlow for defining tests alongside documentation to make more readable

