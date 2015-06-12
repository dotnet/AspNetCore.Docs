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

Synchonous filters define both an `On*Event*Executing` and `On*Event*Executed` method.


Action Filters
----------------

*Action Filters* implement either the ``IActionFilter`` or ``IAsyncActionFilter`` interface and their execution 
surrounds the execution of action methods. 

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
            // Code here runs after the action method is called. 

            // Call 'next' to continue execution and see the result.
            var executed = await next();

            // Code here runs after the action method is called.
            // The 'executed.Result' property contains the result of executing the action method.
        }
    }

An as an Action Filter surrounds 

Result Filters
----------------



Exception Filters
----------------

Resource Filters
----------------

Authorization Filters
----------------
