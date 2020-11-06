# POC for MarutiTech

This repo consists of POC that I've developed based on problem statements given by the team.

---

## 1. DICtorParam

This project showcases how to use the constructor paramater with aspnet core dependency injection. It also showcases how this can parameter can be changed at runtime when creating the instance of the class via Service Locator.

[`FinanceService`]( https://github.com/goldytech/POC/blob/master/DICtorParam/Domain/FinanceService.cs) 
has a constructor parameter which is configured `IOptions<T>`

In the [`Startup`](https://github.com/goldytech/POC/blob/master/DICtorParamStartup.cs)
class this is configured by extension method [`AddFinanceService`](https://github.com/goldytech/POC/blob/master/DICtorParam/Infrastructure/FinanceServiceExtensions.cs)

The `FinanceService` is resolved dynamically at runtime in [`FinanceController`](https://github.com/goldytech/POC/blob/master/DICtorParam/Controllers/FinanceController.cs) class in the `GetDocument` method and the `accountId` parameter value is dynamically set...


