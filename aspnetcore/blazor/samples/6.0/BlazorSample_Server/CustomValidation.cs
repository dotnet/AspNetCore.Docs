using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorSample
{
    public class CustomValidation : ComponentBase
    {
        private ValidationMessageStore? messageStore;
    
        [CascadingParameter]
        private EditContext? CurrentEditContext { get; set; }
    
        protected override void OnInitialized()
        {
            if (CurrentEditContext is null)
            {
                throw new InvalidOperationException(
                    $"{nameof(CustomValidation)} requires a cascading " +
                    $"parameter of type {nameof(EditContext)}. " +
                    $"For example, you can use {nameof(CustomValidation)} " +
                    $"inside an {nameof(EditForm)}.");
            }
    
            messageStore = new(CurrentEditContext);
    
            CurrentEditContext.OnValidationRequested += (s, e) => 
                messageStore?.Clear();
            CurrentEditContext.OnFieldChanged += (s, e) => 
                messageStore?.Clear(e.FieldIdentifier);
        }
    
        public void DisplayErrors(Dictionary<string, List<string>> errors)
        {
            if (CurrentEditContext is not null)
            {
                foreach (var err in errors)
                {
                    messageStore?.Add(CurrentEditContext.Field(err.Key), err.Value);
                }
    
                CurrentEditContext.NotifyValidationStateChanged();
            }
        }
    
        public void ClearErrors()
        {
            messageStore?.Clear();
            CurrentEditContext?.NotifyValidationStateChanged();
        }
    }
}
