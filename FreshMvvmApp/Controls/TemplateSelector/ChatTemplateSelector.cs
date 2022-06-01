using KantimeEvv.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace KantimeEvv.Controls.TemplateSelector
{
    public class ChatTemplateSelector : DataTemplateSelector
    {
        public DataTemplate SentTemplate { get; set; }
        public DataTemplate ReceivedTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var message = item as ChatMessage;

            if(message != null)
            {
                if (message.IsSent)
                {
                    return SentTemplate;
                }
                else
                {
                    return ReceivedTemplate;
                }
            }
            return null;
           
        }
    }
}
