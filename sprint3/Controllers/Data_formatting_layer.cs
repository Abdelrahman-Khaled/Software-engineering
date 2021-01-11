using sprint3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sprint3.Controllers
{
    public class Data_formatting_layer
    {
        private Booking_SystemDBEntities1 db = new Booking_SystemDBEntities1();
        public SM construct_notification_Message(User x,string request) {
            SM text_message = new SM();
            String temp = "";
            foreach (var item in db.notifications_temp)
            {
                if (item.func == request)
                {
                    temp = item.content_text;
                    break;
                }
            }
            if (request == "log_in")
            {
                bool flag = false;
                String name = "";
                foreach (var item in db.Users)
                {
                    if (item.Email == x.Email && item.Password == x.Password)
                    {
                        flag = true;
                        x.Name = item.Name;
                        break;
                    }
                }
                if (flag)
                {
                    temp = temp.Replace("{x}", x.Name);
                    temp = temp.Replace("{y}", "New wave");
                    text_message.context = temp;
                    return text_message;
                }
                else
                {
                    text_message.context = "sorry log in failed please check your credentials";
                    return text_message;
                }
            }
            else if (request == "reg")
            {
                temp = temp.Replace("{x}", x.Name);
                temp = temp.Replace("{y}", "New wave");
                text_message.context = temp;
                return text_message;    
            }

            return null;
        }

        
    }
}