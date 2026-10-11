# BBU Catalog Service

ASP.NET Core API responsible for catalog book registration.

## Endpoint

- `POST /api/books`

The request shape follows the Google Books-like structure in `book.json`. The service stores a catalog UUID in `Books.CatalogId` and normalizes authors, publisher, categories, identifiers, image links, and panelization summary into separate tables.
