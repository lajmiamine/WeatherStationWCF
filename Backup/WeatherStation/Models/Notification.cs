using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using WeatherStation.AppData;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WeatherStation.Models
{
    public class Notification
    {
        [HiddenInput(DisplayValue = true)]
        public int Id_Notif { get; set; }

        [Required]
        [Display(Name = "alert")]
        public string message { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "vue")]
        public bool vue { get; set; }

        [Required]
        [Display(Name = "id exploitation")]
        public int id_exp { get; set; }

        [Required]
        [Display(Name = "id noeud")]
        public int id_noeud { get; set; }
    }

    public interface INotificationService
    {
        List<Notification> GetListNotification();
        List<Notification> GetNotificationByIdExp(int idExp);
        List<Notification> GetData();
        int SetNotificationVisibilityById(int idExp, List<int> notifs);
    }

    public class NotificationService : INotificationService
    {
        AgricultureEntities entities = new AgricultureEntities();

        public List<Notification> GetListNotification()
        {
            var notificationList = entities.notification;
            List<Notification> _notificaList = new List<Notification>();
            foreach (var _notif in notificationList)
            {
                _notificaList.Add(new Notification
                {
                    Id_Notif = _notif.IdNotif,
                    message = _notif.MessgeNotif,
                    Date = (DateTime)_notif.DateNotif,
                 });
            }
            return _notificaList;
        }

        public List<Notification> GetNotificationByIdExp(int idExp)
        {
            var notificationList = entities.notification.Where(x => x.implanter_noeud_exploitation.secteur.parcelle.exploitation.IdExploitation == idExp);
            List<Notification> _notificaList = new List<Notification>();
            foreach (var _notif in notificationList)
            {
                _notificaList.Add(new Notification
                {
                    Id_Notif = _notif.IdNotif,
                    message = _notif.MessgeNotif,
                    Date = (DateTime)_notif.DateNotif,
                    vue = (bool)_notif.Vue,
                    id_exp = (int)_notif.implanter_noeud_exploitation.secteur.parcelle.exploitation.IdExploitation
                });
            }
            return _notificaList;
        }

        public List<Notification> GetData()
        {
//            SqlDependency.Start(ConfigurationManager.ConnectionStrings["AgricultureEntities"].ConnectionString);
//            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["AgricultureEntities"].ConnectionString))
//            {
//                connection.Open();
//                using (SqlCommand command = new SqlCommand(@"SELECT [IdNotif],[MessgeNotif],[FK_IdNode]
//               FROM [dbo].[notification]", connection))
//                {
//                    // Make sure the command object does not already have
//                    // a notification object associated with it.
//                    command.Notification = null;

//                    SqlDependency dependency = new SqlDependency(command);
//                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

//                    if (connection.State == ConnectionState.Closed)
//                        connection.Open();

//                    using (var reader = command.ExecuteReader())
//                        return reader.Cast<IDataRecord>()
//                            .Select(x => new Notification()
//                            {
//                                Id_Notif = x.GetInt32(0),
//                                message = x.GetString(1),
//                                id_noeud = x.GetInt32(2),
                                
//                                //DateImplementation = x.GetDateTime(2),
//                            }).ToList();
//                }
//            }
            return null;
        }

        public int SetNotificationVisibilityById(int idExp, List<int> notifs)
        {
            //SqlDependency.Stop(ConfigurationManager.ConnectionStrings["AgricultureEntities"].ConnectionString);
            //var notificationList = entities.notification.Where(x => x.implanter_noeud_exploitation.secteur.parcelle.exploitation.IdExploitation == idExp);
            //if (notifs != null)
            //{
            //    foreach (var _notif in notificationList)
            //    {
            //        for (var u = 0; u < notifs.Count; u++)
            //        {
            //            if (notifs[u] == _notif.IdNotif)
            //            {
            //                _notif.Vue = true;

            //            }
            //        }
            //    }
            //}

            return entities.SaveChanges();
        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            NotifHub.Show();
        }
    }
}