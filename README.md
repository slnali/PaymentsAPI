# Assumptions made

- Basic CRUD API, didn't stretch too far with enforcing CRUD for persistence as it would require more "Boilerplate" code
- Create Payment sends response to Merchant to confirm that payment was created, have not hidden card details here though

# Future improvements

- Currently just created a quick in memory data store, for production of course data should be persisted to backend database
- Given that data might be queried in across a range of columns perhaps SQL database would be best
- DI Container for handling dependencies e.g. using framework like Lamar
- Enforce some data validation checks at the model level but controller should perhaps contain a validation checker to make sure the payment is valid

