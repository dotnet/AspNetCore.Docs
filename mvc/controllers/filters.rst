.. include:: /../common/stub-topic.txt

-|stub-icon| Filters
===================

*Filters* in ASP.NET MVC allow you to decorate your controllers and actions with code that runs before or after a
particular stage in the execution pipeline. Filters can be configured globally, per-controller, or per-action to apply
policies contextually to manage cross-cutting concerns.

Each kind of filter will be executed at a different stage in the pipeline, and thus has its own set of intended
scenarios. Choose what kind of filter to create based on the task you need it to perform. The following sections
will contain more information about the kinds of scenarios each kind is optimized for.

.. image:: _static/filter_stages.png

Each filter kind supports both synchronous and asynchronous filters though separate interface definitions.
Choose the sync or async variant depending on what kind of task you need to perform in the filter, they are 
interchangeable from the framework's point-of-view.

Synchonous filters define both an `On*Stage*Executing` and `On*Stage*Executed` method (with noted exceptions). The 
`On*Stage*Executing` method will be called before the event pipeline stage by the *Stage* name, and the
`On*Stage*Executed` method will be called after the pipeline stage named by the *Stage* name. See the following
sections for annotated code samples of each filter kind.

Asynchronous filters define a single `On*Stage*ExectionAsync` method that will surround execution of the pipeline stage
named by *Stage*. The `On*Stage*ExectionAsync` method is provided a `*Stage*ExectionDelegate` delegate which will
execute the pipeline stage named by *Stage* when invoked and awaited. See the following sections for annotated code
samples of each filter kind.


Action Filters
----------------

*Action Filters* implement either the ``IActionFilter`` or ``IAsyncActionFilter`` interface and their execution 
surrounds the execution of action methods.

Action filters are ideal for any logic that needs to see the results of model binding, or modify the controller or
inputs to an action method. Additionally action filters can see and most directly modify the results of an action
method.

.. code-block:: c#

    public class MyActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Code here runs before the action method is called.
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Code here runs after the action method is called. 
            // The 'context.Result' property contains the result of executing the action method.
        }
    }

    public class MyAsyncActionFilter : IAsyncActionFilter
    {
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Code here runs before the action method is called. 

            // Call 'next' to continue execution.
            var executed = await next();

            // Code here runs after the action method is called.
            // The 'executed.Result' property contains the result of executing the action method.
        }
    }

As the `OnActionExecuting` method runs before the action method, it can manipulate the inputs to the action by changing
`ActionExecutingContext.ActionArguments` or manipulate the controller through `ActionExecutingContext.Controller`. An
`OnActionExecuting` method can short-circuit execution of the action method and subsequent action filters by setting
`ActionExecutingContext.Result`. Throwing an exception in an `OnActionExecuting` method will also prevent execution of
the action method and subsequent filters, but will be treated as a failure instead of successful result.

The `OnActionExecuted` method runs after the action method, and can see and manipulate the results of the action
through the `ActionExecutedContext.Result` property. `ActionExecutedContext.Canceled` will be set to true if the action
execution was short-circuited by another filter. `ActionExecutedContext.Exception` will be set to a non-null value if
the action or a subsequent action filter threw an exception. Setting `ActionExecutedContext.Exception` to null
effectively 'handles' an exception, and `ActionExectedContext.Result` will be executed as-if it were returned from the
action method normally.

For an `IAsyncActionFilter` the `OnActionExecutionAsync` combines all the possibilites of `OnActionExecuting` and
`OnActionExecuted`. A call to `await next()` on the `ActionExecutionDelegate` will execute any subsequent action
filters and the action method, returning an `ActionExecutedContext`. To short-circuit inside of an
`OnActionExecutionAsync`, set `ActionExecutingContext.Result` and do not call the `ActionExectionDelegate`.


Result Filters
----------------

*Result Filters* implement either the ``IResultFilter`` or ``IAsyncResultFilter`` interface and their execution 
surrounds the execution of action results. Result filters are only executed for successful results - when the action or
action filters produces an action result. Result filters are not executed when exception filters handle an exception.

Result filters are ideal for any logic that needs to directly surround view execution or formatter execution. Result
filters can replace or modify the action result that's responsible for producing the response.

.. code-block:: c#

    public class MyResultFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            // Code here runs before the action result is executed.
            // The 'context.Result' property contains the result about to be executed.
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            // Code here runs after the action result is executed.
        }
    }

    public class MyAsyncResultFilter : IAsyncResultFilter
    {
        public Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            // Code here runs before the action result is executed. 
            // The 'context.Result' property contains the result about to be executed.

            // Call 'next' to continue execution.
            var executed = await next();

            // Code here runs after the action result is executed.
        }
    }

As the `OnResultExecuting` method runs before the action action, it can manipulate the action result through
`ResultExecutingContext.Result`. An `OnResultExecuting` method can short-circuit execution of the action result and
subsequent result filters by setting `ResultExecutingContext.Cancel` to true. If short-circuited, MVC will not modify 
the response; take care to write to the response object directly when short-circuiting. Throwing an exception in an
`OnResultExecuting` method will also prevent execution of the action result and subsequent filters, but will be treated
as a failure instead of successful result.

The `OnResultExecuted` method runs after the action action, at this point if no exception was thrown, the response has
likely be sent to the client and cannot be changed further. `ResultExecutedContext.Canceled` will be set to true if the
action result execution was short-circuited by another filter. `ResultExecutedContext.Exception` will be set to a
non-null value if the action result or a subsequent result filter threw an exception. Setting
`ResultExecutedContext.Exception` to null effectively 'handles' an exception and will prevent the exeception from being
rethrown by MVC later in the pipeline. If handling an exception in a result filter, consider whether or not it's
appropriate to write any data to the response. The action result may have thrown partway through its execution, and if
the headers have already been flushed to the client there's no proper recourse to send a failure status code.

For an `IAsyncResultFilter` the `OnResultExecutionAsync` combines all the possibilites of `OnAResultExecuting` and
`OnResultExecuted`. A call to `await next()` on the `ResultExecutionDelegate` will execute any subsequent result
filters and the action result, returning a `ResultExecutedContext`. To short-circuit inside of an
`OnResultExecutionAsync`, set `ResultExecutingContext.Cancel` to true and do not call the `ResultExectionDelegate`.

Exception Filters
----------------

Resource Filters
----------------

Authorization Filters
----------------
