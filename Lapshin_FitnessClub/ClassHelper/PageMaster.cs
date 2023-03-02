using Lapshin_FitnessClub.Pages;
using Lapshin_FitnessClub.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lapshin_FitnessClub.ClassHelper
{
    public static class PageMaster
    {
        //Pages
        public static Authorisation authorisation = new Authorisation();
        public static Registration registration = new Registration();
        public static ServiceList serviceList = new ServiceList();
        public static AdminPanel adminPanel = new AdminPanel();
    }
}
