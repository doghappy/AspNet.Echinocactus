# Echinocactus

Sharp tool for ASP.NET

## JsonHandler

Get request data from QueryString/Form/InputStream

```cs
var jsonHandler = new JsonHandler(Context);

int page = jsonHandler.GetQueryStringValue<int>("PageIndex");

string token = jsonHandler.GetFormValue<string>("Token");

var model = jsonHandler.GetBodyValue<UserModel>();
```

## ValueConverter

### DataRow

```cs
DataRow row = GetDataRow();

bool isDeleted = row.GetCellValue<bool>("IsDeleted");

User user = row.As<User>();
```

### DataTable

```cs
DataTable table = GetDataTable();
var users = table.As<User>();
```

## Pagination

```cs
protected Pagination Pagination { get; private set; }

...

var jsonHandler = new JsonHandler(Context);
int page = jsonHandler.GetQueryStringValue<int>("PageIndex");
if (page < 1)
    page = 1;
Pagination = new Pagination(page, 10)
{
    PreviousText = "&lt;",
    NextText = "&gt;",
    FirstPageText = "&lt;&lt;",
    LastPageText = "&gt;&gt;"
};
Pagination.TotalItems = GetTotalItems();
Pagination.Append = $"页码 {pagination.Page} / {pagination.TotalPages}";
TableFooter.InnerHtml = pagination.GetPageNumberLinks(p => $"/Test.aspx?PageIndex={p}");
```

![Pagination](imgs/pagination.png)

## Publish

```bash
nuget pack -Prop Configuration=Release
nuget push DogHappy.AspNet.Echinocactus.1.0.0-alpha.1.nupkg -Source nuget.org -ApiKey xxxxx
```