using Newtonsoft.Json;

namespace Invest.CrossCutting.Common.ExceptionHandler.ViewModels
{
    public class ItemValidationFailedViewModel
    {
        public string Field { get; set; }
        public string Message { get; set; }

        public ItemValidationFailedViewModel()
        {
        }

        public ItemValidationFailedViewModel(string message)
        {
            Field = null;
            Message = message;
        }

        public ItemValidationFailedViewModel(string field, string message)
        {
            Field = string.IsNullOrEmpty(field) ? null : field;
            Message = message;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, DefaultJsonConverterSetting.Settings);
        }
    }
}