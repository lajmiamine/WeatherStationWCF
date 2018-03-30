using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using WeatherStation.AppData;

namespace WeatherStation.Models
{
    public class MesuresClimatModel
    {

        [Display(Name = "Mesure de l'Humidité")]
        public int IdMesureClimat { get; set; }

        [Required]
        [Display(Name = "Date de la Mesure")]
        public DateTime DateMesure { get; set; }

        [Required]
        [Display(Name = "Mesure de la Température")]
        public float? TemperatureClimat { get; set; }

        [Required]
        [Display(Name = "Mesure de l'Humidité")]
        public float? HumiditeClimat { get; set; }

        [Required]
        [Display(Name = "Mesure de la pluviometrie")]
        public float? PluviometrieClimat { get; set; }

        [Required]
        [Display(Name = "Mesure du Rayonnement")]
        public float? RayonnementClimat { get; set; }

        [Required]
        [Display(Name = "Mesure de la vitesse du vent")]
        public float? VitesseVentClimat { get; set; }

        [Required]
        [Display(Name = "Mesure de sens du vent")]
        public float? SensVentClimat { get; set; }

        [Display(Name = "Noeud Climat Père")]
        public NodeClimatModel ParentNode { get; set; }

        [Display(Name = "Id Noeud Climat Père")]
        public int IdParentNode { get; set; }
    }

    public class MesuresClimatChoix
    {
        [Display(Name = "Mesure de l'Humidité")]
        public int IdMesureClimat { get; set; }

        [Required]
        [Display(Name = "Date de la Mesure")]
        public DateTime DateMesure { get; set; }

        [Required]
        [Display(Name = "Mesure de la Température")]
        public float? TemperatureClimat { get; set; }

        [Required]
        [Display(Name = "Mesure de l'Humidité")]
        public float? HumiditeClimat { get; set; }

        [Required]
        [Display(Name = "Mesure de la pluviometrie")]
        public float? PluviometrieClimat { get; set; }

        [Required]
        [Display(Name = "Mesure du Rayonnement")]
        public float? RayonnementClimat { get; set; }

        [Required]
        [Display(Name = "Mesure de la vitesse du vent")]
        public float? VitesseVentClimat { get; set; }

        [Required]
        [Display(Name = "Mesure de sens du vent")]
        public float? SensVentClimat { get; set; }

        [Display(Name = "Noeud Climat Père")]
        public NodeClimatModel ParentNode { get; set; }

        [Display(Name = "Id Noeud Climat Père")]
        public int IdParentNode { get; set; }

        [Display(Name = "Etat de la température")]
        public bool Temp_Etat { get; set; }

        [Display(Name = "Etat de l'humidité")]
        public bool Hum_Etat { get; set; }

        [Display(Name = "Etat de la pluviométrie")]
        public bool Pluv_Etat { get; set; }

        [Display(Name = "Etat du rayonnement solaire")]
        public bool Ray_Etat { get; set; }

        [Display(Name = "Etat de la vitesse du vent")]
        public bool Vitesse_Etat { get; set; }

        [Display(Name = "Etat du sens du vent")]
        public bool Sens_Etat { get; set; }
    }

    public class MesuresTemperatureClimatModel
    {
        [Display(Name = "Mesure de l'Température")]
        public int IdMesureClimat { get; set; }

        [Required]
        [Display(Name = "Date de la Mesure")]
        public DateTime DateMesure { get; set; }

        [Required]
        [Display(Name = "Mesure de la Température")]
        public float? TemperatureClimat { get; set; }

        [Display(Name = "Id Noeud Climat Père")]
        public int IdParentNode { get; set; }
    }

    public class MesuresHumiditeClimat
    {
        [Display(Name = "Mesure de l'humidite")]
        public int IdMesureClimat { get; set; }

        [Required]
        [Display(Name = "Date de la Mesure")]
        public DateTime DateMesure { get; set; }

        [Required]
        [Display(Name = "Mesure de l'humidite")]
        public float? HumiditeClimat { get; set; }

        [Display(Name = "Id Noeud Climat Père")]
        public int IdParentNode { get; set; }
    }

    public class MesuresPluviometrieClimat
    {
        [Display(Name = "Mesure du pluviometrie")]
        public int IdMesureClimat { get; set; }

        [Required]
        [Display(Name = "Date de la Mesure")]
        public DateTime DateMesure { get; set; }

        [Required]
        [Display(Name = "Mesure du pluviometrie")]
        public float? PluviometrieClimat { get; set; }

        [Display(Name = "Id Noeud Climat Père")]
        public int IdParentNode { get; set; }
    }

    public class MesuresRayonnementClimat
    {
        [Display(Name = "Mesure du pluviometrie")]
        public int IdMesureClimat { get; set; }

        [Required]
        [Display(Name = "Date de la Mesure")]
        public DateTime DateMesure { get; set; }

        [Required]
        [Display(Name = "Mesure du rayonnement")]
        public float? RayonnementClimat { get; set; }

        [Display(Name = "Id Noeud Climat Père")]
        public int IdParentNode { get; set; }
    }

    public class MesuresVitesseVentClimat
    {
        [Display(Name = "Mesure du vitesse du vent")]
        public int IdMesureClimat { get; set; }

        [Required]
        [Display(Name = "Date de la Mesure")]
        public DateTime DateMesure { get; set; }

        [Required]
        [Display(Name = "Mesure du vitesse du vent")]
        public float? VitesseVentClimat { get; set; }

        [Display(Name = "Id Noeud Climat Père")]
        public int IdParentNode { get; set; }
    }

    public class MesuresSensVentClimat
    {
        [Display(Name = "Mesure du sens du vent")]
        public int IdMesureClimat { get; set; }

        [Required]
        [Display(Name = "Date de la Mesure")]
        public DateTime DateMesure { get; set; }

        [Required]
        [Display(Name = "Mesure du sens du vent")]
        public float? SensVentClimat { get; set; }

        [Display(Name = "Id Noeud Climat Père")]
        public int IdParentNode { get; set; }
    }

    public class MesuresTemperatureMoyClimatModel
    {
        [Display(Name = "Mesure de l'Humidité")]
        public int IdMesureMoyClimat { get; set; }

        [Required]
        [Display(Name = "Date de la Mesure")]
        public DateTime? DateMesureMoy { get; set; }

        [Required]
        [Display(Name = "Temperature Min")]
        public float? Tmin { get; set; }

        [Required]
        [Display(Name = "Temperature Max")]
        public float? Tmax { get; set; }

        [Required]
        [Display(Name = "Temperature Moyenne")]
        public float? Tmoy { get; set; }

        //[Display(Name = "Noeud Climat Père")]
        //public ImplNoeudClimatModels ParentNode { get; set; }

        [Display(Name = "Id Noeud Climat Père")]
        public int IdParentNode { get; set; }
    }

    public class MesuresMoyClimatModel
    {
        [Display(Name = "Mesure de l'Humidité")]
        public int IdMesureMoyClimat { get; set; }

        [Required]
        [Display(Name = "Date de la Mesure")]
        public DateTime? DateMesureMoy { get; set; }

        [Required]
        [Display(Name = "Temperature Moyenne")]
        public float? Tmoy { get; set; }

        [Required]
        [Display(Name = "Humidité Moyenne")]
        public float? Hmoy { get; set; }

        [Required]
        [Display(Name = "Rayonnement Moyenne")]
        public float? Rmoy { get; set; }

        [Required]
        [Display(Name = "Rayonnement estimation")]
        public bool? Rest { get; set; }

        [Required]
        [Display(Name = "Vitesse Vent Moyenne")]
        public float? Vmoy { get; set; }

        [Required]
        [Display(Name = "Vitesse Vent estimation")]
        public bool? Vest { get; set; }

        [Required]
        [Display(Name = "EvapoTranspiration Réference")]
        public float? ET0 { get; set; }

        //[Display(Name = "Noeud Climat Père")]
        //public ImplNoeudClimatModels ParentNode { get; set; }

        [Display(Name = "Id Noeud Climat Père")]
        public int IdParentNode { get; set; }

        [Display(Name = "Id Exploitation Mère")]
        public int IdExploitation { get; set; }
    }

    #region Services
    public interface IMesuresClimatService
    {
        //Temperature
        List<MesuresTemperatureClimatModel> GetMesureTemperatureByIdClimatByMinute(int idNoeudClimat, string startDate);
        List<MesuresTemperatureClimatModel> GetMesuresTemperatureByIdClimatByDayByMinute(int idNoeudClimat, string startTime);
        List<MesuresTemperatureClimatModel> GetMesureTemperatureByWeekByMinute(int idNoeudClimat, string startTime);
        List<MesuresTemperatureClimatModel> GetMesuresByIdClimatByIntervalByMinute(int idNoeudClimat, string startDate, string endDate);
        List<MesuresTemperatureMoyClimatModel> GetMesuresMoyByIdClimatByMonthByDay(int idNoeudClimat, string startDate);
        List<MesuresTemperatureClimatModel> GetData();

        //Humidité
        List<MesuresHumiditeClimat> GetMesureHumditeByIdClimatByMinute(int idNoeudClimat, string startTime);
        List<MesuresHumiditeClimat> GetMesuresHumiditeByIdClimatByDayByMinute(int idNoeudClimat, string startTime);
        List<MesuresHumiditeClimat> GetMesureHumiditeByWeekByMinute(int idNoeudClimat, string startTime);
        List<MesuresHumiditeClimat> GetMesuresHumditeByIdClimatByIntervalByMinute(int idNoeudClimat, string startTime, string endTime);
        
        //pluviometrie
        List<MesuresPluviometrieClimat> GetMesuresPluviometrieByIdClimatByIntervalByMinute(int idNoeudClimat, string startTime, string endTime);
        List<MesuresPluviometrieClimat> GetMesurePluviometrieByWeekByMinute(int idNoeudClimat, string startTime);
        List<MesuresPluviometrieClimat> GetMesurePluviometrieByIdClimatByMinute(int idNoeudClimat, string startTime);
        List<MesuresPluviometrieClimat> GetMesuresPluviometrieByIdClimatByDayByMinute(int idNoeudClimat, string startTime);
        List<MesuresPluviometrieClimat> GetPluviometrieByIdClimatToday(int idNoeudClimat);
        
        //rayonnement solaire
        List<MesuresRayonnementClimat> GetMesureRayonnementByWeekByMinute(int idNoeudClimat, string startTime);
        List<MesuresRayonnementClimat> GetMesureRayonnementByIdClimatByMinute(int idNoeudClimat, string startTime);
        List<MesuresRayonnementClimat> GetMesuresRayonnementByIdClimatByDayByMinute(int idNoeudClimat, string startTime);
        List<MesuresRayonnementClimat> GetMesuresRayonnementByIdClimatByIntervalByMinute(int idNoeudClimat, string startTime, string endTime);

        //vitesse vent
        List<MesuresVitesseVentClimat> GetMesureVitesseVentByWeekByMinute(int idNoeudClimat, string startTime);
        List<MesuresVitesseVentClimat> GetMesureVitesseVentByIdClimatByMinute(int idNoeudClimat, string startTime);
        List<MesuresVitesseVentClimat> GetMesuresVitesseVentByIdClimatByDayByMinute(int idNoeudClimat, string startTime);
        List<MesuresVitesseVentClimat> GetMesuresVitesseVentByIdClimatByIntervalByMinute(int idNoeudClimat, string startTime, string endTime);

        //sens  vent
        List<MesuresSensVentClimat> GetMesuresSensVentByIdClimatByIntervalByMinute(int idNoeudClimat, string startTime, string endTime);
        List<MesuresSensVentClimat> GetMesureSensVentByWeekByMinute(int idNoeudClimat, string startTime);
        List<MesuresSensVentClimat> GetMesureSensVentByIdClimatByMinute(int idNoeudClimat, string startTime);
        List<MesuresSensVentClimat> GetMesuresSensVentByIdClimatByDayByMinute(int idNoeudClimat, string startTime);

        //superposées
        List<MesuresClimatModel> GetAllMesuresByIdClimatByIntervalByMinute(int idNoeudClimat, string startTime, string endTime);
        List<MesuresClimatChoix> GetAllMesuresByIdClimatByDayByMinute(int idNoeudClimat, Boolean temp, Boolean hum, Boolean pluv, Boolean ray, Boolean vitessevent, Boolean sensvent);
        List<MesuresClimatModel> GetMesureByIdClimatByMinute(int idNoeudClimat, string startTime);
        List<MesuresClimatModel> GetAllMesuresByIdClimatByDayByMinute(int idNoeudClimat, string startTime);
        List<MesuresClimatModel> GetMesureByWeekByMinute(int idNoeudClimat, string startTime);
       
        List<MesuresMoyClimatModel> GetMesuresMoyClimatByIdExploitationOneWeek(int idExploit, string startTime);
        List<MesuresMoyClimatModel> GetMesuresMoyClimatByIdExploitationOneMonth(int idExploit, string startTime);
        
    }

    public class MesuresClimatService : IMesuresClimatService
    {
        #region Property Mesures
        private readonly AgricultureEntities entities = new AgricultureEntities();
        #endregion

        //*******************************************température**********************************************************/

        //one hour
        public List<MesuresTemperatureClimatModel> GetMesureTemperatureByIdClimatByMinute(int idNoeudClimat, string startTime)
        {
            DateTime startDate = DateTime.ParseExact(startTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime endDate = startDate.AddHours(1);

            var mTemp1 = entities.mesure_noeudclimat.Where(x => x.mesure_noeud.FK_IdImplNoeud == idNoeudClimat);
            var mTemp = mTemp1.Where(x => x.mesure_noeud.DateMesureNoeud.Value >= startDate && x.mesure_noeud.DateMesureNoeud.Value <= endDate);
            List<MesuresTemperatureClimatModel> mTemp2 = mTemp.Select(x => new MesuresTemperatureClimatModel
            {
                // delete millisecond fields from DateTime attribute
                DateMesure = EntityFunctions.AddSeconds(EntityFunctions.AddMilliseconds(x.mesure_noeud.DateMesureNoeud.Value, -x.mesure_noeud.DateMesureNoeud.Value.Millisecond).Value, -x.mesure_noeud.DateMesureNoeud.Value.Second).Value,
                IdMesureClimat = x.IdMesureNoeud,
                TemperatureClimat = x.TemperatureAir.Value,
                IdParentNode = x.mesure_noeud.FK_IdImplNoeud
            }).ToList();

            DateTime _startDate = startDate;
            List<MesuresTemperatureClimatModel> _mTemp = new List<MesuresTemperatureClimatModel>();

            for (var f = 0; f < 60; f++)
            {
                MesuresTemperatureClimatModel mnc = new MesuresTemperatureClimatModel();
                mnc = mTemp2.FirstOrDefault(x => DateTime.Compare(x.DateMesure, _startDate) == 0);
                if (mnc != null)
                {
                    _mTemp.Add(mnc);
                }
                else
                {
                    _mTemp.Add(new MesuresTemperatureClimatModel
                    {
                        DateMesure = _startDate,
                        TemperatureClimat = null,
                        IdParentNode = idNoeudClimat
                    });
                }
                _startDate = _startDate.AddMinutes(1);
                mnc = null;
            }

            return _mTemp;
        }

        //by day
        public List<MesuresTemperatureClimatModel> GetMesuresTemperatureByIdClimatByDayByMinute(int idNoeudClimat, string startTime)
        {
            DateTime startDate;
            if (startTime.Length < 20) // c# time 05/09/2014 15:12:51
            {
                startDate = DateTime.ParseExact(startTime, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).Date;
            }
            else // js time
            {
                startDate = DateTime.ParseExact(startTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).Date;
            }

            //SQLNotifier Notifier = new SQLNotifier();
            //System.Data.DataTable dt = Notifier.RegisterDependency();

            // mesures_climat = new AutoRefreshWrapper<mesure_noeudclimat>(entities.mesure_noeudclimat, RefreshMode.StoreWins);
            // extract all climate mesures related to one node
            var mTemp1 = entities.mesure_noeudclimat/*mesures_climat*/.Where(x => x.mesure_noeud.FK_IdImplNoeud == idNoeudClimat);
            // select from previous list mesures related to proposed day
            var mTemp = mTemp1.Where(x => EntityFunctions.TruncateTime(x.mesure_noeud.DateMesureNoeud.Value) == startDate.Date);
            //var mTemp = mTemp1.Where(x => x.mesure_noeud.DateMesureNoeud.Value.Date == startDate.Date);
            int nb = mTemp.Count();

            // fill 'MesuresTemperatureClimat' class with mesures from previous list
            List<MesuresTemperatureClimatModel> mTemp2 = mTemp.Select(x => new MesuresTemperatureClimatModel
            {
                // delete millisecond fields from DateTime attribute
                DateMesure = EntityFunctions.AddSeconds(EntityFunctions.AddMilliseconds(x.mesure_noeud.DateMesureNoeud.Value, -x.mesure_noeud.DateMesureNoeud.Value.Millisecond).Value, -x.mesure_noeud.DateMesureNoeud.Value.Second).Value,
                //DateMesure = x.mesure_noeud.DateMesureNoeud.Value.AddMilliseconds(-x.mesure_noeud.DateMesureNoeud.Value.Millisecond).AddSeconds(-x.mesure_noeud.DateMesureNoeud.Value.Second),
                IdMesureClimat = x.IdMesureNoeud,
                TemperatureClimat = x.TemperatureAir.Value,
                IdParentNode = x.mesure_noeud.FK_IdImplNoeud
            }).ToList();

            DateTime _startDate = startDate.Date;
            List<MesuresTemperatureClimatModel> _mTemp = new List<MesuresTemperatureClimatModel>();

            for (int i = 0; i < 24; i++)
            {
                for (int f = 0; f < 60; f++)
                {
                    MesuresTemperatureClimatModel mnc = new MesuresTemperatureClimatModel();
                    mnc = mTemp2.FirstOrDefault(x => DateTime.Compare(x.DateMesure, _startDate) == 0);
                    //System.Threading.Tasks.Task.Factory.StartNew(() =>
                    //{                     
                    //}).Wait();
                    if (mnc != null)
                    {
                        _mTemp.Add(mnc);
                    }
                    else
                    {
                        _mTemp.Add(new MesuresTemperatureClimatModel
                        {
                            DateMesure = _startDate,
                            TemperatureClimat = null,
                            IdParentNode = idNoeudClimat
                        });
                    }
                    _startDate = _startDate.AddMinutes(1);
                    mnc = null;
                }
            };

            return _mTemp;
        }

        //one week
        public List<MesuresTemperatureClimatModel> GetMesureTemperatureByWeekByMinute(int idNoeudClimat, string startTime)
        {
            DateTime startDate = DateTime.ParseExact(startTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime endDate = startDate.AddDays(7);

            var mTemp1 = entities.mesure_noeudclimat.Where(x => x.mesure_noeud.FK_IdImplNoeud == idNoeudClimat);
            var mTemp = mTemp1.Where(x => (EntityFunctions.TruncateTime(x.mesure_noeud.DateMesureNoeud.Value) >= startDate.Date) && (EntityFunctions.TruncateTime(x.mesure_noeud.DateMesureNoeud.Value) <= endDate.Date));
            List<MesuresTemperatureClimatModel> mTemp2 = mTemp.Select(x => new MesuresTemperatureClimatModel
            {
                // delete millisecond fields from DateTime attribute
                DateMesure = EntityFunctions.AddSeconds(EntityFunctions.AddMilliseconds(x.mesure_noeud.DateMesureNoeud.Value, -x.mesure_noeud.DateMesureNoeud.Value.Millisecond).Value, -x.mesure_noeud.DateMesureNoeud.Value.Second).Value,
                IdMesureClimat = x.IdMesureNoeud,
                TemperatureClimat = x.TemperatureAir.Value,
                IdParentNode = x.mesure_noeud.FK_IdImplNoeud
            }).ToList();

            DateTime _startDate = startDate.Date;
            List<MesuresTemperatureClimatModel> _mTemp = new List<MesuresTemperatureClimatModel>();

            for (int k = 0; k < 7; k++)
            {
                for (int i = 0; i < 24; i++)
                {
                    for (var f = 0; f < 60; f++)
                    {
                        MesuresTemperatureClimatModel mnc = new MesuresTemperatureClimatModel();
                        mnc = mTemp2.FirstOrDefault(x => DateTime.Compare(x.DateMesure, _startDate) == 0);
                        if (mnc != null)
                        {
                            _mTemp.Add(mnc);
                        }
                        else
                        {
                            _mTemp.Add(new MesuresTemperatureClimatModel
                            {
                                DateMesure = _startDate,
                                TemperatureClimat = null,
                                IdParentNode = idNoeudClimat
                            });
                        }
                        _startDate = _startDate.AddMinutes(1);
                        mnc = null;
                    }
                }
            }

            return _mTemp;
        }

        //periode
        public List<MesuresTemperatureClimatModel> GetMesuresByIdClimatByIntervalByMinute(int idNoeudClimat, string startTime, string endTime)
        {
            DateTime startDate = DateTime.ParseExact(startTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(endTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

            var mTemp1 = entities.mesure_noeudclimat.Where(x => x.mesure_noeud.FK_IdImplNoeud == idNoeudClimat);
            var mTemp = mTemp1.Where(x => x.mesure_noeud.DateMesureNoeud.Value >= startDate && x.mesure_noeud.DateMesureNoeud.Value <= endDate);
            List<MesuresTemperatureClimatModel> mTemp2 = mTemp.Select(x => new MesuresTemperatureClimatModel
            {
                // delete millisecond fields from DateTime attribute
                DateMesure = EntityFunctions.AddSeconds(EntityFunctions.AddMilliseconds(x.mesure_noeud.DateMesureNoeud.Value, -x.mesure_noeud.DateMesureNoeud.Value.Millisecond).Value, -x.mesure_noeud.DateMesureNoeud.Value.Second).Value,
                IdMesureClimat = x.IdMesureNoeud,
                TemperatureClimat = x.TemperatureAir.Value,
                IdParentNode = x.mesure_noeud.FK_IdImplNoeud
            }).ToList();

            List<MesuresTemperatureClimatModel> _mTemp = new List<MesuresTemperatureClimatModel>();
            TimeSpan ts = endDate - startDate;
            DateTime _startDate = startDate.Date;

            for (var f = 0; f < ts.TotalMinutes; f++)
            {
                MesuresTemperatureClimatModel mnc = new MesuresTemperatureClimatModel();
                mnc = mTemp2.FirstOrDefault(x => DateTime.Compare(x.DateMesure, _startDate) == 0);
                if (mnc != null)
                {
                    _mTemp.Add(mnc);
                }
                else
                {
                    _mTemp.Add(new MesuresTemperatureClimatModel
                    {
                        DateMesure = _startDate,
                        TemperatureClimat = null,
                        IdParentNode = idNoeudClimat
                    });
                }
                _startDate = _startDate.AddMinutes(1);
                mnc = null;
            }

            return _mTemp;
        }

        public List<MesuresTemperatureClimatModel> GetData()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["AgricultureEntities"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(@"SELECT TOP 1 x1.[IdMesureNoeud], x1.[DateMesureNoeud], x2.[TemperatureAir], x1.[FK_IdImplNoeud]
                                                                FROM [dbo].[mesure_noeud] x1, [dbo].[mesure_noeudclimat] x2
                                                                WHERE x1.[IdMesureNoeud] = x2.[IdMesureNoeud]
                                                                ORDER BY x1.[DateMesureNoeud] DESC", connection))
                {
                    // Make sure the command object does not already have
                    // a notification object associated with it.
                    command.Notification = null;

                    //SqlDependency dependency = new SqlDependency(command);
                    //dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    using (var reader = command.ExecuteReader())
                        return reader.Cast<IDataRecord>()
                            .Select(x => new MesuresTemperatureClimatModel()
                            {
                                IdMesureClimat = x.GetInt32(0),
                                DateMesure = x.GetDateTime(1),
                                TemperatureClimat = x.GetFloat(2),
                                IdParentNode = x.GetInt32(3),
                            }).ToList();
                }
            }
        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            MesureHub.Show();
        }

        /*********************Mesures Temperature Moyennes **************************************/

        public List<MesuresTemperatureMoyClimatModel> GetMesuresMoyByIdClimatByMonthByDay(int idNoeudClimat, string startTime)
        {
            DateTime startDate = DateTime.ParseExact(startTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime _startDate = new DateTime(startDate.Year, startDate.Month, 1);
            DateTime endDate = _startDate.AddMonths(1);
            var mesuresMoyenne = entities.mesure_noeudclimat_moyennes.Where(x => x.FK_IdNoeudClimat == idNoeudClimat).ToList().Where(x => DateTime.Compare(x.JourMesure.Value.Date, _startDate.Date) >= 0 && DateTime.Compare(x.JourMesure.Value.Date, endDate.Date) < 0);
            List<MesuresTemperatureMoyClimatModel> _mTemp = new List<MesuresTemperatureMoyClimatModel>();

            for (var day = 1; day <= 30; day++)
            {
                var mm = mesuresMoyenne.FirstOrDefault(x => x.JourMesure.Value.Date == _startDate);
                if (mm != null)
                {
                    _mTemp.Add(new MesuresTemperatureMoyClimatModel
                    {
                        IdMesureMoyClimat = mm.IdMesureMoyenne,
                        DateMesureMoy = mm.JourMesure.Value,
                        //Tmax = mm.TMax.Value,
                        //Tmin = mm.TMin.Value,
                        Tmoy = mm.TMoy.Value,
                        // ParentNode = new ImplNoeudClimatService().GetNodeClimatById(mm.FK_IdNoeudClimat)
                    });
                }
                else
                {
                    _mTemp.Add(new MesuresTemperatureMoyClimatModel
                    {
                        DateMesureMoy = _startDate,
                        Tmax = null,
                        Tmin = null,
                        Tmoy = null,
                    });
                }
                _startDate = _startDate.AddDays(1);
            }

            return _mTemp;
        }

        /***********************************Humidité*************************************/

        //one day
        public List<MesuresHumiditeClimat> GetMesuresHumiditeByIdClimatByDayByMinute(int idNoeudClimat, string startTime)
        {
            DateTime startDate;
            if (startTime.Length < 20) // c# time 05/09/2014 15:12:51
            {
                startDate = DateTime.ParseExact(startTime, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).Date;
            }
            else // js time
            {
                startDate = DateTime.ParseExact(startTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).Date;
            }

            //mesures_climat = new AutoRefreshWrapper<mesure_noeudclimat>(entities.mesure_noeudclimat, RefreshMode.StoreWins);
            // extract all climate mesures related to one node
            var mTemp1 = entities.mesure_noeudclimat/*mesures_climat*/.Where(x => x.mesure_noeud.FK_IdImplNoeud == idNoeudClimat);
            // select from previous list mesures related to proposed day
            var mTemp = mTemp1.Where(x => EntityFunctions.TruncateTime(x.mesure_noeud.DateMesureNoeud.Value) == startDate.Date);
            //var mTemp = mTemp1.Where(x => x.mesure_noeud.DateMesureNoeud.Value.Date == startDate.Date);
            int nb = mTemp.Count();

            // fill 'MesuresTemperatureClimat' class with mesures from previous list
            List<MesuresHumiditeClimat> mTemp2 = mTemp.Select(x => new MesuresHumiditeClimat
            {
                // delete millisecond fields from DateTime attribute
                DateMesure = EntityFunctions.AddSeconds(EntityFunctions.AddMilliseconds(x.mesure_noeud.DateMesureNoeud.Value, -x.mesure_noeud.DateMesureNoeud.Value.Millisecond).Value, -x.mesure_noeud.DateMesureNoeud.Value.Second).Value,
                //DateMesure = x.mesure_noeud.DateMesureNoeud.Value.AddMilliseconds(-x.mesure_noeud.DateMesureNoeud.Value.Millisecond).AddSeconds(-x.mesure_noeud.DateMesureNoeud.Value.Second),
                IdMesureClimat = x.IdMesureNoeud,
                HumiditeClimat = x.HumiditeAir.Value,
                IdParentNode = x.mesure_noeud.FK_IdImplNoeud
            }).ToList();

            DateTime _startDate = startDate.Date;
            List<MesuresHumiditeClimat> _mTemp = new List<MesuresHumiditeClimat>();

            for (int i = 0; i < 24; i++)
            {
                for (int f = 0; f < 60; f++)
                {
                    MesuresHumiditeClimat mnc = new MesuresHumiditeClimat();
                    mnc = mTemp2.FirstOrDefault(x => DateTime.Compare(x.DateMesure, _startDate) == 0);
                    //System.Threading.Tasks.Task.Factory.StartNew(() =>
                    //{                     
                    //}).Wait();
                    if (mnc != null)
                    {
                        _mTemp.Add(mnc);
                    }
                    else
                    {
                        _mTemp.Add(new MesuresHumiditeClimat
                        {
                            DateMesure = _startDate,
                            HumiditeClimat = null,
                            IdParentNode = idNoeudClimat
                        });
                    }
                    _startDate = _startDate.AddMinutes(1);
                    mnc = null;
                }
            };

            return _mTemp;
        }

        //one hour
        public List<MesuresHumiditeClimat> GetMesureHumditeByIdClimatByMinute(int idNoeudClimat, string startTime)
        {
            DateTime startDate = DateTime.ParseExact(startTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime endDate = startDate.AddHours(1);

            var mTemp1 = entities.mesure_noeudclimat.Where(x => x.mesure_noeud.FK_IdImplNoeud == idNoeudClimat);
            var mTemp = mTemp1.Where(x => x.mesure_noeud.DateMesureNoeud.Value >= startDate && x.mesure_noeud.DateMesureNoeud.Value <= endDate);
            List<MesuresHumiditeClimat> mTemp2 = mTemp.Select(x => new MesuresHumiditeClimat
            {
                // delete millisecond fields from DateTime attribute
                DateMesure = EntityFunctions.AddSeconds(EntityFunctions.AddMilliseconds(x.mesure_noeud.DateMesureNoeud.Value, -x.mesure_noeud.DateMesureNoeud.Value.Millisecond).Value, -x.mesure_noeud.DateMesureNoeud.Value.Second).Value,
                IdMesureClimat = x.IdMesureNoeud,
                HumiditeClimat = x.TemperatureAir.Value,
                IdParentNode = x.mesure_noeud.FK_IdImplNoeud
            }).ToList();

            DateTime _startDate = startDate;
            List<MesuresHumiditeClimat> _mTemp = new List<MesuresHumiditeClimat>();

            for (var f = 0; f < 60; f++)
            {
                MesuresHumiditeClimat mnc = new MesuresHumiditeClimat();
                mnc = mTemp2.FirstOrDefault(x => DateTime.Compare(x.DateMesure, _startDate) == 0);
                if (mnc != null)
                {
                    _mTemp.Add(mnc);
                }
                else
                {
                    _mTemp.Add(new MesuresHumiditeClimat
                    {
                        DateMesure = _startDate,
                        HumiditeClimat = null,
                        IdParentNode = idNoeudClimat
                    });
                }
                _startDate = _startDate.AddMinutes(1);
                mnc = null;
            }

            return _mTemp;
        }

        //one week
        public List<MesuresHumiditeClimat> GetMesureHumiditeByWeekByMinute(int idNoeudClimat, string startTime)
        {
            DateTime startDate = DateTime.ParseExact(startTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime endDate = startDate.AddDays(7);

            var mTemp1 = entities.mesure_noeudclimat.Where(x => x.mesure_noeud.FK_IdImplNoeud == idNoeudClimat);
            var mTemp = mTemp1.Where(x => (EntityFunctions.TruncateTime(x.mesure_noeud.DateMesureNoeud.Value) >= startDate.Date) && (EntityFunctions.TruncateTime(x.mesure_noeud.DateMesureNoeud.Value) <= endDate.Date));
            List<MesuresHumiditeClimat> mTemp2 = mTemp.Select(x => new MesuresHumiditeClimat
            {
                // delete millisecond fields from DateTime attribute
                DateMesure = EntityFunctions.AddSeconds(EntityFunctions.AddMilliseconds(x.mesure_noeud.DateMesureNoeud.Value, -x.mesure_noeud.DateMesureNoeud.Value.Millisecond).Value, -x.mesure_noeud.DateMesureNoeud.Value.Second).Value,
                IdMesureClimat = x.IdMesureNoeud,
                HumiditeClimat = x.HumiditeAir.Value,
                IdParentNode = x.mesure_noeud.FK_IdImplNoeud
            }).ToList();

            DateTime _startDate = startDate.Date;
            List<MesuresHumiditeClimat> _mTemp = new List<MesuresHumiditeClimat>();

            for (int k = 0; k < 7; k++)
            {
                for (int i = 0; i < 24; i++)
                {
                    for (var f = 0; f < 60; f++)
                    {
                        MesuresHumiditeClimat mnc = new MesuresHumiditeClimat();
                        mnc = mTemp2.FirstOrDefault(x => DateTime.Compare(x.DateMesure, _startDate) == 0);
                        if (mnc != null)
                        {
                            _mTemp.Add(mnc);
                        }
                        else
                        {
                            _mTemp.Add(new MesuresHumiditeClimat
                            {
                                DateMesure = _startDate,
                                HumiditeClimat = null,
                                IdParentNode = idNoeudClimat
                            });
                        }
                        _startDate = _startDate.AddMinutes(1);
                        mnc = null;
                    }
                }
            }

            return _mTemp;
        }

        //by interval
        public List<MesuresHumiditeClimat> GetMesuresHumditeByIdClimatByIntervalByMinute(int idNoeudClimat, string startTime, string endTime)
        {
            DateTime startDate = DateTime.ParseExact(startTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(endTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            var mTemp1 = entities.mesure_noeudclimat.Where(x => x.mesure_noeud.FK_IdImplNoeud == idNoeudClimat);
            var mTemp = mTemp1.Where(x => x.mesure_noeud.DateMesureNoeud >= startDate && x.mesure_noeud.DateMesureNoeud <= endDate);

            List<MesuresHumiditeClimat> mTemp2 = mTemp.Select(x => new MesuresHumiditeClimat
            {
                // delete millisecond fields from DateTime attribute
                DateMesure = EntityFunctions.AddSeconds(EntityFunctions.AddMilliseconds(x.mesure_noeud.DateMesureNoeud.Value, -x.mesure_noeud.DateMesureNoeud.Value.Millisecond).Value, -x.mesure_noeud.DateMesureNoeud.Value.Second).Value,
                IdMesureClimat = x.IdMesureNoeud,
                HumiditeClimat = x.HumiditeAir.Value,
                IdParentNode = x.mesure_noeud.FK_IdImplNoeud
            }).ToList();
            List<MesuresHumiditeClimat> _mTemp = new List<MesuresHumiditeClimat>();
            TimeSpan ts = endDate - startDate;
            DateTime _startDate = startDate.Date;
            for (int j = 0; j < ts.Days; j++)
            {
                for (int i = 0; i < 24; i++)
                {
                    for (var f = 0; f < 60; f++)
                    {

                        MesuresHumiditeClimat mnc = new MesuresHumiditeClimat();
                        mnc = mTemp2.FirstOrDefault(x => DateTime.Compare(x.DateMesure, _startDate) == 0);
                        if (mnc != null)
                        {
                            _mTemp.Add(mnc);
                        }
                        else
                        {
                            _mTemp.Add(new MesuresHumiditeClimat
                            {
                                DateMesure = _startDate,
                                HumiditeClimat = null,
                                IdParentNode = idNoeudClimat
                            });
                        }
                        _startDate = _startDate.AddMinutes(1);
                        mnc = null;
                    }
                }
            }
            return _mTemp;
        }

        //************************************Pluviometrie*****************************************//
        //by hour
        public List<MesuresPluviometrieClimat> GetMesurePluviometrieByIdClimatByMinute(int idNoeudClimat, string startTime)
        {
            DateTime startDate = DateTime.ParseExact(startTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime endDate = startDate.AddHours(1);

            var mTemp1 = entities.mesure_noeudclimat.Where(x => x.mesure_noeud.FK_IdImplNoeud == idNoeudClimat);
            var mTemp = mTemp1.Where(x => x.mesure_noeud.DateMesureNoeud.Value >= startDate && x.mesure_noeud.DateMesureNoeud.Value <= endDate);
            List<MesuresPluviometrieClimat> mTemp2 = mTemp.Select(x => new MesuresPluviometrieClimat
            {
                // delete millisecond fields from DateTime attribute
                DateMesure = EntityFunctions.AddSeconds(EntityFunctions.AddMilliseconds(x.mesure_noeud.DateMesureNoeud.Value, -x.mesure_noeud.DateMesureNoeud.Value.Millisecond).Value, -x.mesure_noeud.DateMesureNoeud.Value.Second).Value,
                IdMesureClimat = x.IdMesureNoeud,
                PluviometrieClimat = x.Pluviometrie.Value,
                IdParentNode = x.mesure_noeud.FK_IdImplNoeud
            }).ToList();

            DateTime _startDate = startDate;
            List<MesuresPluviometrieClimat> _mTemp = new List<MesuresPluviometrieClimat>();

            for (var f = 0; f < 60; f++)
            {
                MesuresPluviometrieClimat mnc = new MesuresPluviometrieClimat();
                mnc = mTemp2.FirstOrDefault(x => DateTime.Compare(x.DateMesure, _startDate) == 0);
                if (mnc != null)
                {
                    _mTemp.Add(mnc);
                }
                else
                {
                    _mTemp.Add(new MesuresPluviometrieClimat
                    {
                        DateMesure = _startDate,
                        PluviometrieClimat = null,
                        IdParentNode = idNoeudClimat
                    });
                }
                _startDate = _startDate.AddMinutes(1);
                mnc = null;
            }

            return _mTemp;
        }



        //today

        public List<MesuresPluviometrieClimat> GetPluviometrieByIdClimatToday(int idNoeudClimat)
        {
            DateTime startTime = DateTime.Now;
            var mTemp = entities.mesure_noeudclimat.Where(x => x.mesure_noeud.FK_IdImplNoeud == idNoeudClimat).ToList().Where(x => DateTime.Compare(x.mesure_noeud.DateMesureNoeud.Value.Date, startTime.Date) == 0);
            DateTime _startDate = startTime.Date;
            List<MesuresPluviometrieClimat> _mTemp = new List<MesuresPluviometrieClimat>();

            for (int i = 0; i < 24; i++)
            {
                for (var f = 0; f < 60; f++)
                {
                    mesure_noeudclimat mnc = mTemp.ToList().Find(x => DateTime.Compare(x.mesure_noeud.DateMesureNoeud.Value.AddMilliseconds(-x.mesure_noeud.DateMesureNoeud.Value.Millisecond), _startDate) == 0);
                    if (mnc != null)
                    {
                        _mTemp.Add(new MesuresPluviometrieClimat
                        {
                            IdMesureClimat = mnc.IdMesureNoeud,
                            DateMesure = mnc.mesure_noeud.DateMesureNoeud.Value,
                            PluviometrieClimat = mnc.Pluviometrie.Value,
                            IdParentNode = idNoeudClimat
                        });
                    }
                    else
                    {
                        _mTemp.Add(new MesuresPluviometrieClimat
                        {
                            DateMesure = _startDate,
                            PluviometrieClimat = null,
                            IdParentNode = idNoeudClimat
                        });
                    }
                    _startDate = _startDate.AddMinutes(1);
                    mnc = null;
                }
            }

            return _mTemp;
        }

        //one day

        public List<MesuresPluviometrieClimat> GetMesuresPluviometrieByIdClimatByDayByMinute(int idNoeudClimat, string startTime)
        {
            DateTime startDate;
            if (startTime.Length < 20) // c# time 05/09/2014 15:12:51
            {
                startDate = DateTime.ParseExact(startTime, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).Date;
            }
            else // js time
            {
                startDate = DateTime.ParseExact(startTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).Date;
            }

            // mesures_climat = new AutoRefreshWrapper<mesure_noeudclimat>(entities.mesure_noeudclimat, RefreshMode.StoreWins);
            // extract all climate mesures related to one node
            var mTemp1 = entities.mesure_noeudclimat/*mesures_climat*/.Where(x => x.mesure_noeud.FK_IdImplNoeud == idNoeudClimat);
            // select from previous list mesures related to proposed day
            var mTemp = mTemp1.Where(x => EntityFunctions.TruncateTime(x.mesure_noeud.DateMesureNoeud.Value) == startDate.Date);
            //var mTemp = mTemp1.Where(x => x.mesure_noeud.DateMesureNoeud.Value.Date == startDate.Date);
            int nb = mTemp.Count();

            // fill 'MesuresTemperatureClimat' class with mesures from previous list
            List<MesuresPluviometrieClimat> mTemp2 = mTemp.Select(x => new MesuresPluviometrieClimat
            {
                // delete millisecond fields from DateTime attribute
                DateMesure = EntityFunctions.AddSeconds(EntityFunctions.AddMilliseconds(x.mesure_noeud.DateMesureNoeud.Value, -x.mesure_noeud.DateMesureNoeud.Value.Millisecond).Value, -x.mesure_noeud.DateMesureNoeud.Value.Second).Value,
                //DateMesure = x.mesure_noeud.DateMesureNoeud.Value.AddMilliseconds(-x.mesure_noeud.DateMesureNoeud.Value.Millisecond).AddSeconds(-x.mesure_noeud.DateMesureNoeud.Value.Second),
                IdMesureClimat = x.IdMesureNoeud,
                PluviometrieClimat = x.Pluviometrie.Value,
                IdParentNode = x.mesure_noeud.FK_IdImplNoeud
            }).ToList();

            DateTime _startDate = startDate.Date;
            List<MesuresPluviometrieClimat> _mTemp = new List<MesuresPluviometrieClimat>();

            for (int i = 0; i < 24; i++)
            {
                for (int f = 0; f < 60; f++)
                {
                    MesuresPluviometrieClimat mnc = new MesuresPluviometrieClimat();
                    mnc = mTemp2.FirstOrDefault(x => DateTime.Compare(x.DateMesure, _startDate) == 0);
                    //System.Threading.Tasks.Task.Factory.StartNew(() =>
                    //{                     
                    //}).Wait();
                    if (mnc != null)
                    {
                        _mTemp.Add(mnc);
                    }
                    else
                    {
                        _mTemp.Add(new MesuresPluviometrieClimat
                        {
                            DateMesure = _startDate,
                            PluviometrieClimat = null,
                            IdParentNode = idNoeudClimat
                        });
                    }
                    _startDate = _startDate.AddMinutes(1);
                    mnc = null;
                }
            };

            return _mTemp;
        }

        //one week

        public List<MesuresPluviometrieClimat> GetMesurePluviometrieByWeekByMinute(int idNoeudClimat, string startTime)
        {
            DateTime startDate = DateTime.ParseExact(startTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime endDate = startDate.AddDays(7);

            var mTemp1 = entities.mesure_noeudclimat.Where(x => x.mesure_noeud.FK_IdImplNoeud == idNoeudClimat);
            var mTemp = mTemp1.Where(x => (EntityFunctions.TruncateTime(x.mesure_noeud.DateMesureNoeud.Value) >= startDate.Date) && (EntityFunctions.TruncateTime(x.mesure_noeud.DateMesureNoeud.Value) <= endDate.Date));
            List<MesuresPluviometrieClimat> mTemp2 = mTemp.Select(x => new MesuresPluviometrieClimat
            {
                // delete millisecond fields from DateTime attribute
                DateMesure = EntityFunctions.AddSeconds(EntityFunctions.AddMilliseconds(x.mesure_noeud.DateMesureNoeud.Value, -x.mesure_noeud.DateMesureNoeud.Value.Millisecond).Value, -x.mesure_noeud.DateMesureNoeud.Value.Second).Value,
                IdMesureClimat = x.IdMesureNoeud,
                PluviometrieClimat = x.Pluviometrie.Value,
                IdParentNode = x.mesure_noeud.FK_IdImplNoeud
            }).ToList();

            DateTime _startDate = startDate.Date;
            List<MesuresPluviometrieClimat> _mTemp = new List<MesuresPluviometrieClimat>();

            for (int k = 0; k < 7; k++)
            {
                for (int i = 0; i < 24; i++)
                {
                    for (var f = 0; f < 60; f++)
                    {
                        MesuresPluviometrieClimat mnc = new MesuresPluviometrieClimat();
                        mnc = mTemp2.FirstOrDefault(x => DateTime.Compare(x.DateMesure, _startDate) == 0);
                        if (mnc != null)
                        {
                            _mTemp.Add(mnc);
                        }
                        else
                        {
                            _mTemp.Add(new MesuresPluviometrieClimat
                            {
                                DateMesure = _startDate,
                                PluviometrieClimat = null,
                                IdParentNode = idNoeudClimat
                            });
                        }
                        _startDate = _startDate.AddMinutes(1);
                        mnc = null;
                    }
                }
            }

            return _mTemp;
        }



        //by interval

        public List<MesuresPluviometrieClimat> GetMesuresPluviometrieByIdClimatByIntervalByMinute(int idNoeudClimat, string startTime, string endTime)
        {
            DateTime startDate = DateTime.ParseExact(startTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(endTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

            var mTemp1 = entities.mesure_noeudclimat.Where(x => x.mesure_noeud.FK_IdImplNoeud == idNoeudClimat);
            var mTemp = mTemp1.Where(x => x.mesure_noeud.DateMesureNoeud.Value >= startDate && x.mesure_noeud.DateMesureNoeud.Value <= endDate);
            List<MesuresPluviometrieClimat> mTemp2 = mTemp.Select(x => new MesuresPluviometrieClimat
            {
                // delete millisecond fields from DateTime attribute
                DateMesure = EntityFunctions.AddSeconds(EntityFunctions.AddMilliseconds(x.mesure_noeud.DateMesureNoeud.Value, -x.mesure_noeud.DateMesureNoeud.Value.Millisecond).Value, -x.mesure_noeud.DateMesureNoeud.Value.Second).Value,
                IdMesureClimat = x.IdMesureNoeud,
                PluviometrieClimat = x.Pluviometrie.Value,
                IdParentNode = x.mesure_noeud.FK_IdImplNoeud
            }).ToList();

            List<MesuresPluviometrieClimat> _mTemp = new List<MesuresPluviometrieClimat>();
            TimeSpan ts = endDate - startDate;
            DateTime _startDate = startDate.Date;
            for (int j = 0; j < ts.Days; j++)
            {
                for (int i = 0; i < 24; i++)
                {
                    for (var f = 0; f < 60; f++)
                    {
                        MesuresPluviometrieClimat mnc = new MesuresPluviometrieClimat();
                        mnc = mTemp2.FirstOrDefault(x => DateTime.Compare(x.DateMesure, _startDate) == 0);
                        if (mnc != null)
                        {
                            _mTemp.Add(mnc);
                        }
                        else
                        {
                            _mTemp.Add(new MesuresPluviometrieClimat
                            {
                                DateMesure = _startDate,
                                PluviometrieClimat = null,
                                IdParentNode = idNoeudClimat
                            });
                        }
                        _startDate = _startDate.AddMinutes(1);
                        mnc = null;
                    }
                }
            }
            return _mTemp;
        }
        //One hour 
        public List<MesuresRayonnementClimat> GetMesureRayonnementByIdClimatByMinute(int idNoeudClimat, string startTime)
        {
            DateTime startDate = DateTime.ParseExact(startTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime endDate = startDate.AddHours(1);

            var mTemp1 = entities.mesure_noeudclimat.Where(x => x.mesure_noeud.FK_IdImplNoeud == idNoeudClimat);
            var mTemp = mTemp1.Where(x => x.mesure_noeud.DateMesureNoeud.Value >= startDate && x.mesure_noeud.DateMesureNoeud.Value <= endDate);
            List<MesuresRayonnementClimat> mTemp2 = mTemp.Select(x => new MesuresRayonnementClimat
            {
                // delete millisecond fields from DateTime attribute
                DateMesure = EntityFunctions.AddSeconds(EntityFunctions.AddMilliseconds(x.mesure_noeud.DateMesureNoeud.Value, -x.mesure_noeud.DateMesureNoeud.Value.Millisecond).Value, -x.mesure_noeud.DateMesureNoeud.Value.Second).Value,
                IdMesureClimat = x.IdMesureNoeud,
                RayonnementClimat = x.RayonnementSolaire.Value,
                IdParentNode = x.mesure_noeud.FK_IdImplNoeud
            }).ToList();

            DateTime _startDate = startDate;
            List<MesuresRayonnementClimat> _mTemp = new List<MesuresRayonnementClimat>();

            for (var f = 0; f < 60; f++)
            {
                MesuresRayonnementClimat mnc = new MesuresRayonnementClimat();
                mnc = mTemp2.FirstOrDefault(x => DateTime.Compare(x.DateMesure, _startDate) == 0);
                if (mnc != null)
                {
                    _mTemp.Add(mnc);
                }
                else
                {
                    _mTemp.Add(new MesuresRayonnementClimat
                    {
                        DateMesure = _startDate,
                        RayonnementClimat = null,
                        IdParentNode = idNoeudClimat
                    });
                }
                _startDate = _startDate.AddMinutes(1);
                mnc = null;
            }

            return _mTemp;
        }



        //One day


        public List<MesuresRayonnementClimat> GetMesuresRayonnementByIdClimatByDayByMinute(int idNoeudClimat, string startTime)
        {
            DateTime startDate;
            if (startTime.Length < 20) // c# time 05/09/2014 15:12:51
            {
                startDate = DateTime.ParseExact(startTime, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).Date;
            }
            else // js time
            {
                startDate = DateTime.ParseExact(startTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).Date;
            }
      
            // mesures_climat = new AutoRefreshWrapper<mesure_noeudclimat>(entities.mesure_noeudclimat, RefreshMode.StoreWins);
            // extract all climate mesures related to one node
            var mTemp1 = entities.mesure_noeudclimat/*mesures_climat*/.Where(x => x.mesure_noeud.FK_IdImplNoeud == idNoeudClimat);
            // select from previous list mesures related to proposed day
            var mTemp = mTemp1.Where(x => EntityFunctions.TruncateTime(x.mesure_noeud.DateMesureNoeud.Value) == startDate.Date);
            //var mTemp = mTemp1.Where(x => x.mesure_noeud.DateMesureNoeud.Value.Date == startDate.Date);
            int nb = mTemp.Count();

            // fill 'MesuresTemperatureClimat' class with mesures from previous list
            List<MesuresRayonnementClimat> mTemp2 = mTemp.Select(x => new MesuresRayonnementClimat
            {
                // delete millisecond fields from DateTime attribute
                DateMesure = EntityFunctions.AddSeconds(EntityFunctions.AddMilliseconds(x.mesure_noeud.DateMesureNoeud.Value, -x.mesure_noeud.DateMesureNoeud.Value.Millisecond).Value, -x.mesure_noeud.DateMesureNoeud.Value.Second).Value,
                //DateMesure = x.mesure_noeud.DateMesureNoeud.Value.AddMilliseconds(-x.mesure_noeud.DateMesureNoeud.Value.Millisecond).AddSeconds(-x.mesure_noeud.DateMesureNoeud.Value.Second),
                IdMesureClimat = x.IdMesureNoeud,
                RayonnementClimat = x.RayonnementSolaire.Value,
                IdParentNode = x.mesure_noeud.FK_IdImplNoeud
            }).ToList();

            DateTime _startDate = startDate.Date;
            List<MesuresRayonnementClimat> _mTemp = new List<MesuresRayonnementClimat>();

            for (int i = 0; i < 24; i++)
            {
                for (int f = 0; f < 60; f++)
                {
                    MesuresRayonnementClimat mnc = new MesuresRayonnementClimat();
                    mnc = mTemp2.FirstOrDefault(x => DateTime.Compare(x.DateMesure, _startDate) == 0);
                    //System.Threading.Tasks.Task.Factory.StartNew(() =>
                    //{                     
                    //}).Wait();
                    if (mnc != null)
                    {
                        _mTemp.Add(mnc);
                    }
                    else
                    {
                        _mTemp.Add(new MesuresRayonnementClimat
                        {
                            DateMesure = _startDate,
                            RayonnementClimat = null,
                            IdParentNode = idNoeudClimat
                        });
                    }
                    _startDate = _startDate.AddMinutes(1);
                    mnc = null;
                }

                //System.Threading.Tasks.Parallel.For(0, 60, f =>
                //{
                //var mnc = mTemp2.FirstOrDefault(x => DateTime.Compare(x.DateMesure, _startDate) == 0);
                //if (mnc != null)
                //{
                //    _mTemp.Add(mnc);
                //}
                //else
                //{
                //    _mTemp.Add(new MesuresTemperatureClimat
                //    {
                //        DateMesure = _startDate,
                //        TemperatureClimat = null,
                //        IdParentNode = idNoeudClimat
                //    });
                //}
                //_startDate = _startDate.AddMinutes(1);
                //mnc = null;
                //});
            };

            return _mTemp;
        }




        //one week


        public List<MesuresRayonnementClimat> GetMesureRayonnementByWeekByMinute(int idNoeudClimat, string startTime)
        {
            DateTime startDate = DateTime.ParseExact(startTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime endDate = startDate.AddDays(7);

            var mTemp1 = entities.mesure_noeudclimat.Where(x => x.mesure_noeud.FK_IdImplNoeud == idNoeudClimat);
            var mTemp = mTemp1.Where(x => (EntityFunctions.TruncateTime(x.mesure_noeud.DateMesureNoeud.Value) >= startDate.Date) && (EntityFunctions.TruncateTime(x.mesure_noeud.DateMesureNoeud.Value) <= endDate.Date));
            List<MesuresRayonnementClimat> mTemp2 = mTemp.Select(x => new MesuresRayonnementClimat
            {
                // delete millisecond fields from DateTime attribute
                DateMesure = EntityFunctions.AddSeconds(EntityFunctions.AddMilliseconds(x.mesure_noeud.DateMesureNoeud.Value, -x.mesure_noeud.DateMesureNoeud.Value.Millisecond).Value, -x.mesure_noeud.DateMesureNoeud.Value.Second).Value,
                IdMesureClimat = x.IdMesureNoeud,
                RayonnementClimat = x.RayonnementSolaire.Value,
                IdParentNode = x.mesure_noeud.FK_IdImplNoeud
            }).ToList();

            DateTime _startDate = startDate.Date;
            List<MesuresRayonnementClimat> _mTemp = new List<MesuresRayonnementClimat>();

            for (int k = 0; k < 7; k++)
            {
                for (int i = 0; i < 24; i++)
                {
                    for (var f = 0; f < 60; f++)
                    {
                        MesuresRayonnementClimat mnc = new MesuresRayonnementClimat();
                        mnc = mTemp2.FirstOrDefault(x => DateTime.Compare(x.DateMesure, _startDate) == 0);
                        if (mnc != null)
                        {
                            _mTemp.Add(mnc);
                        }
                        else
                        {
                            _mTemp.Add(new MesuresRayonnementClimat
                            {
                                DateMesure = _startDate,
                                RayonnementClimat = null,
                                IdParentNode = idNoeudClimat
                            });
                        }
                        _startDate = _startDate.AddMinutes(1);
                        mnc = null;
                    }
                }
            }

            return _mTemp;
        }



        //interval

        public List<MesuresRayonnementClimat> GetMesuresRayonnementByIdClimatByIntervalByMinute(int idNoeudClimat, string startTime, string endTime)
        {
            DateTime startDate = DateTime.ParseExact(startTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(endTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

            var mTemp1 = entities.mesure_noeudclimat.Where(x => x.mesure_noeud.FK_IdImplNoeud == idNoeudClimat);
            var mTemp = mTemp1.Where(x => x.mesure_noeud.DateMesureNoeud.Value >= startDate && x.mesure_noeud.DateMesureNoeud.Value <= endDate);
            List<MesuresRayonnementClimat> mTemp2 = mTemp.Select(x => new MesuresRayonnementClimat
            {
                // delete millisecond fields from DateTime attribute
                DateMesure = EntityFunctions.AddSeconds(EntityFunctions.AddMilliseconds(x.mesure_noeud.DateMesureNoeud.Value, -x.mesure_noeud.DateMesureNoeud.Value.Millisecond).Value, -x.mesure_noeud.DateMesureNoeud.Value.Second).Value,
                IdMesureClimat = x.IdMesureNoeud,
                RayonnementClimat = x.RayonnementSolaire.Value,
                IdParentNode = x.mesure_noeud.FK_IdImplNoeud
            }).ToList();

            List<MesuresRayonnementClimat> _mTemp = new List<MesuresRayonnementClimat>();
            TimeSpan ts = endDate - startDate;
            DateTime _startDate = startDate.Date;
            for (int j = 0; j < ts.Days; j++)
            {
                for (int i = 0; i < 24; i++)
                {
                    for (var f = 0; f < 60; f++)
                    {
                        MesuresRayonnementClimat mnc = new MesuresRayonnementClimat();
                        mnc = mTemp2.FirstOrDefault(x => DateTime.Compare(x.DateMesure, _startDate) == 0);
                        if (mnc != null)
                        {
                            _mTemp.Add(mnc);
                        }
                        else
                        {
                            _mTemp.Add(new MesuresRayonnementClimat
                            {
                                DateMesure = _startDate,
                                RayonnementClimat = null,
                                IdParentNode = idNoeudClimat
                            });
                        }
                        _startDate = _startDate.AddMinutes(1);
                        mnc = null;
                    }
                }
            }
            return _mTemp;
        }

        //***********************************vitesse vent ***************************************//

        //one hour
        public List<MesuresVitesseVentClimat> GetMesureVitesseVentByIdClimatByMinute(int idNoeudClimat, string startTime)
        {
            DateTime startDate = DateTime.ParseExact(startTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime endDate = startDate.AddHours(1);

            var mTemp1 = entities.mesure_noeudclimat.Where(x => x.mesure_noeud.FK_IdImplNoeud == idNoeudClimat);
            var mTemp = mTemp1.Where(x => x.mesure_noeud.DateMesureNoeud.Value >= startDate && x.mesure_noeud.DateMesureNoeud.Value <= endDate);
            List<MesuresVitesseVentClimat> mTemp2 = mTemp.Select(x => new MesuresVitesseVentClimat
            {
                // delete millisecond fields from DateTime attribute
                DateMesure = EntityFunctions.AddSeconds(EntityFunctions.AddMilliseconds(x.mesure_noeud.DateMesureNoeud.Value, -x.mesure_noeud.DateMesureNoeud.Value.Millisecond).Value, -x.mesure_noeud.DateMesureNoeud.Value.Second).Value,
                IdMesureClimat = x.IdMesureNoeud,
                VitesseVentClimat = x.RayonnementSolaire.Value,
                IdParentNode = x.mesure_noeud.FK_IdImplNoeud
            }).ToList();

            DateTime _startDate = startDate;
            List<MesuresVitesseVentClimat> _mTemp = new List<MesuresVitesseVentClimat>();

            for (var f = 0; f < 60; f++)
            {
                MesuresVitesseVentClimat mnc = new MesuresVitesseVentClimat();
                mnc = mTemp2.FirstOrDefault(x => DateTime.Compare(x.DateMesure, _startDate) == 0);
                if (mnc != null)
                {
                    _mTemp.Add(mnc);
                }
                else
                {
                    _mTemp.Add(new MesuresVitesseVentClimat
                    {
                        DateMesure = _startDate,
                        VitesseVentClimat = null,
                        IdParentNode = idNoeudClimat
                    });
                }
                _startDate = _startDate.AddMinutes(1);
                mnc = null;
            }

            return _mTemp;
        }
        //periode
        public List<MesuresVitesseVentClimat> GetMesuresVitesseVentByIdClimatByIntervalByMinute(int idNoeudClimat, string startTime, string endTime)
        {
            DateTime startDate = DateTime.ParseExact(startTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(endTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

            var mTemp1 = entities.mesure_noeudclimat.Where(x => x.mesure_noeud.FK_IdImplNoeud == idNoeudClimat);
            var mTemp = mTemp1.Where(x => x.mesure_noeud.DateMesureNoeud.Value >= startDate && x.mesure_noeud.DateMesureNoeud.Value <= endDate);
            List<MesuresVitesseVentClimat> mTemp2 = mTemp.Select(x => new MesuresVitesseVentClimat
            {
                // delete millisecond fields from DateTime attribute
                DateMesure = EntityFunctions.AddSeconds(EntityFunctions.AddMilliseconds(x.mesure_noeud.DateMesureNoeud.Value, -x.mesure_noeud.DateMesureNoeud.Value.Millisecond).Value, -x.mesure_noeud.DateMesureNoeud.Value.Second).Value,
                IdMesureClimat = x.IdMesureNoeud,
                VitesseVentClimat = x.TemperatureAir.Value,
                IdParentNode = x.mesure_noeud.FK_IdImplNoeud
            }).ToList();

            List<MesuresVitesseVentClimat> _mTemp = new List<MesuresVitesseVentClimat>();
            TimeSpan ts = endDate - startDate;
            DateTime _startDate = startDate.Date;
            for (int j = 0; j < ts.Days; j++)
            {
                for (int i = 0; i < 24; i++)
                {
                    for (var f = 0; f < 60; f++)
                    {
                        MesuresVitesseVentClimat mnc = new MesuresVitesseVentClimat();
                        mnc = mTemp2.FirstOrDefault(x => DateTime.Compare(x.DateMesure, _startDate) == 0);
                        if (mnc != null)
                        {
                            _mTemp.Add(mnc);
                        }
                        else
                        {
                            _mTemp.Add(new MesuresVitesseVentClimat
                            {
                                DateMesure = _startDate,
                                VitesseVentClimat = null,
                                IdParentNode = idNoeudClimat
                            });
                        }
                        _startDate = _startDate.AddMinutes(1);
                        mnc = null;
                    }
                }
            }
            return _mTemp;
        }



        //One day
        public List<MesuresVitesseVentClimat> GetMesuresVitesseVentByIdClimatByDayByMinute(int idNoeudClimat, string startTime)
        {
            DateTime startDate;
            if (startTime.Length < 20) // c# time 05/09/2014 15:12:51
            {
                startDate = DateTime.ParseExact(startTime, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).Date;
            }
            else // js time
            {
                startDate = DateTime.ParseExact(startTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).Date;
            }

            // mesures_climat = new AutoRefreshWrapper<mesure_noeudclimat>(entities.mesure_noeudclimat, RefreshMode.StoreWins);
            // extract all climate mesures related to one node
            var mTemp1 = entities.mesure_noeudclimat/*mesures_climat*/.Where(x => x.mesure_noeud.FK_IdImplNoeud == idNoeudClimat);
            // select from previous list mesures related to proposed day
            var mTemp = mTemp1.Where(x => EntityFunctions.TruncateTime(x.mesure_noeud.DateMesureNoeud.Value) == startDate.Date);
            //var mTemp = mTemp1.Where(x => x.mesure_noeud.DateMesureNoeud.Value.Date == startDate.Date);
            int nb = mTemp.Count();

            // fill 'MesuresTemperatureClimat' class with mesures from previous list
            List<MesuresVitesseVentClimat> mTemp2 = mTemp.Select(x => new MesuresVitesseVentClimat
            {
                // delete millisecond fields from DateTime attribute
                DateMesure = EntityFunctions.AddSeconds(EntityFunctions.AddMilliseconds(x.mesure_noeud.DateMesureNoeud.Value, -x.mesure_noeud.DateMesureNoeud.Value.Millisecond).Value, -x.mesure_noeud.DateMesureNoeud.Value.Second).Value,
                //DateMesure = x.mesure_noeud.DateMesureNoeud.Value.AddMilliseconds(-x.mesure_noeud.DateMesureNoeud.Value.Millisecond).AddSeconds(-x.mesure_noeud.DateMesureNoeud.Value.Second),
                IdMesureClimat = x.IdMesureNoeud,
                VitesseVentClimat = x.TemperatureAir.Value,
                IdParentNode = x.mesure_noeud.FK_IdImplNoeud
            }).ToList();

            DateTime _startDate = startDate.Date;
            List<MesuresVitesseVentClimat> _mTemp = new List<MesuresVitesseVentClimat>();

            for (int i = 0; i < 24; i++)
            {
                for (int f = 0; f < 60; f++)
                {
                    MesuresVitesseVentClimat mnc = new MesuresVitesseVentClimat();
                    mnc = mTemp2.FirstOrDefault(x => DateTime.Compare(x.DateMesure, _startDate) == 0);
                    //System.Threading.Tasks.Task.Factory.StartNew(() =>
                    //{                     
                    //}).Wait();
                    if (mnc != null)
                    {
                        _mTemp.Add(mnc);
                    }
                    else
                    {
                        _mTemp.Add(new MesuresVitesseVentClimat
                        {
                            DateMesure = _startDate,
                            VitesseVentClimat = null,
                            IdParentNode = idNoeudClimat
                        });
                    }
                    _startDate = _startDate.AddMinutes(1);
                    mnc = null;
                }

                //System.Threading.Tasks.Parallel.For(0, 60, f =>
                //{
                //var mnc = mTemp2.FirstOrDefault(x => DateTime.Compare(x.DateMesure, _startDate) == 0);
                //if (mnc != null)
                //{
                //    _mTemp.Add(mnc);
                //}
                //else
                //{
                //    _mTemp.Add(new MesuresTemperatureClimat
                //    {
                //        DateMesure = _startDate,
                //        TemperatureClimat = null,
                //        IdParentNode = idNoeudClimat
                //    });
                //}
                //_startDate = _startDate.AddMinutes(1);
                //mnc = null;
                //});
            };

            return _mTemp;
        }
        
        //by week
        public List<MesuresVitesseVentClimat> GetMesureVitesseVentByWeekByMinute(int idNoeudClimat, string startTime)
        {
            DateTime startDate = DateTime.ParseExact(startTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime endDate = startDate.AddDays(7);
            var mTemp1 = entities.mesure_noeudclimat.Where(x => x.mesure_noeud.FK_IdImplNoeud == idNoeudClimat);
            var mTemp = mTemp1.Where(x => (EntityFunctions.TruncateTime(x.mesure_noeud.DateMesureNoeud.Value) >= startDate.Date) && (EntityFunctions.TruncateTime(x.mesure_noeud.DateMesureNoeud.Value) <= endDate.Date));
            List<MesuresVitesseVentClimat> mTemp2 = mTemp.Select(x => new MesuresVitesseVentClimat
            {
                // delete millisecond fields from DateTime attribute
                DateMesure = EntityFunctions.AddSeconds(EntityFunctions.AddMilliseconds(x.mesure_noeud.DateMesureNoeud.Value, -x.mesure_noeud.DateMesureNoeud.Value.Millisecond).Value, -x.mesure_noeud.DateMesureNoeud.Value.Second).Value,
                IdMesureClimat = x.IdMesureNoeud,
                VitesseVentClimat = x.TemperatureAir.Value,
                IdParentNode = x.mesure_noeud.FK_IdImplNoeud
            }).ToList();

            DateTime _startDate = startDate.Date;
            List<MesuresVitesseVentClimat> _mTemp = new List<MesuresVitesseVentClimat>();

            for (int k = 0; k < 7; k++)
            {
                for (int i = 0; i < 24; i++)
                {
                    for (var f = 0; f < 60; f++)
                    {
                        MesuresVitesseVentClimat mnc = new MesuresVitesseVentClimat();
                        mnc = mTemp2.FirstOrDefault(x => DateTime.Compare(x.DateMesure, _startDate) == 0);
                        if (mnc != null)
                        {
                            _mTemp.Add(mnc);
                        }
                        else
                        {
                            _mTemp.Add(new MesuresVitesseVentClimat
                            {
                                DateMesure = _startDate,
                                VitesseVentClimat = null,
                                IdParentNode = idNoeudClimat
                            });
                        }
                        _startDate = _startDate.AddMinutes(1);
                        mnc = null;
                    }
                }
            }

            return _mTemp;
        }
       //*********************************** sens du vent **************************************//

        //one hour
        public List<MesuresSensVentClimat> GetMesureSensVentByIdClimatByMinute(int idNoeudClimat, string startTime)
        {
            DateTime startDate = DateTime.ParseExact(startTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime endDate = startDate.AddHours(1);

            var mTemp1 = entities.mesure_noeudclimat.Where(x => x.mesure_noeud.FK_IdImplNoeud == idNoeudClimat);
            var mTemp = mTemp1.Where(x => x.mesure_noeud.DateMesureNoeud.Value >= startDate && x.mesure_noeud.DateMesureNoeud.Value <= endDate);
            List<MesuresSensVentClimat> mTemp2 = mTemp.Select(x => new MesuresSensVentClimat
            {
                // delete millisecond fields from DateTime attribute
                DateMesure = EntityFunctions.AddSeconds(EntityFunctions.AddMilliseconds(x.mesure_noeud.DateMesureNoeud.Value, -x.mesure_noeud.DateMesureNoeud.Value.Millisecond).Value, -x.mesure_noeud.DateMesureNoeud.Value.Second).Value,
                IdMesureClimat = x.IdMesureNoeud,
                SensVentClimat = x.SensVent.Value,
                IdParentNode = x.mesure_noeud.FK_IdImplNoeud
            }).ToList();

            DateTime _startDate = startDate;
            List<MesuresSensVentClimat> _mTemp = new List<MesuresSensVentClimat>();

            for (var f = 0; f < 60; f++)
            {
                MesuresSensVentClimat mnc = new MesuresSensVentClimat();
                mnc = mTemp2.FirstOrDefault(x => DateTime.Compare(x.DateMesure, _startDate) == 0);
                if (mnc != null)
                {
                    _mTemp.Add(mnc);
                }
                else
                {
                    _mTemp.Add(new MesuresSensVentClimat
                    {
                        DateMesure = _startDate,
                        SensVentClimat = null,
                        IdParentNode = idNoeudClimat
                    });
                }
                _startDate = _startDate.AddMinutes(1);
                mnc = null;
            }

            return _mTemp;
        }


        //One day

        public List<MesuresSensVentClimat> GetMesuresSensVentByIdClimatByDayByMinute(int idNoeudClimat, string startTime)
        {
            DateTime startDate;
            if (startTime.Length < 20) // c# time 05/09/2014 15:12:51
            {
                startDate = DateTime.ParseExact(startTime, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).Date;
            }
            else // js time
            {
                startDate = DateTime.ParseExact(startTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).Date;
            }

            // mesures_climat = new AutoRefreshWrapper<mesure_noeudclimat>(entities.mesure_noeudclimat, RefreshMode.StoreWins);
            // extract all climate mesures related to one node
            var mTemp1 = entities.mesure_noeudclimat/*mesures_climat*/.Where(x => x.mesure_noeud.FK_IdImplNoeud == idNoeudClimat);
            // select from previous list mesures related to proposed day
            var mTemp = mTemp1.Where(x => EntityFunctions.TruncateTime(x.mesure_noeud.DateMesureNoeud.Value) == startDate.Date);
            //var mTemp = mTemp1.Where(x => x.mesure_noeud.DateMesureNoeud.Value.Date == startDate.Date);
            int nb = mTemp.Count();

            // fill 'MesuresTemperatureClimat' class with mesures from previous list
            List<MesuresSensVentClimat> mTemp2 = mTemp.Select(x => new MesuresSensVentClimat
            {
                // delete millisecond fields from DateTime attribute
                DateMesure = EntityFunctions.AddSeconds(EntityFunctions.AddMilliseconds(x.mesure_noeud.DateMesureNoeud.Value, -x.mesure_noeud.DateMesureNoeud.Value.Millisecond).Value, -x.mesure_noeud.DateMesureNoeud.Value.Second).Value,
                //DateMesure = x.mesure_noeud.DateMesureNoeud.Value.AddMilliseconds(-x.mesure_noeud.DateMesureNoeud.Value.Millisecond).AddSeconds(-x.mesure_noeud.DateMesureNoeud.Value.Second),
                IdMesureClimat = x.IdMesureNoeud,
                SensVentClimat = x.SensVent.Value,
                IdParentNode = x.mesure_noeud.FK_IdImplNoeud
            }).ToList();

            DateTime _startDate = startDate.Date;
            List<MesuresSensVentClimat> _mTemp = new List<MesuresSensVentClimat>();

            for (int i = 0; i < 24; i++)
            {
                for (int f = 0; f < 60; f++)
                {
                    MesuresSensVentClimat mnc = new MesuresSensVentClimat();
                    mnc = mTemp2.FirstOrDefault(x => DateTime.Compare(x.DateMesure, _startDate) == 0);
                    //System.Threading.Tasks.Task.Factory.StartNew(() =>
                    //{                     
                    //}).Wait();
                    if (mnc != null)
                    {
                        _mTemp.Add(mnc);
                    }
                    else
                    {
                        _mTemp.Add(new MesuresSensVentClimat
                        {
                            DateMesure = _startDate,
                            SensVentClimat = null,
                            IdParentNode = idNoeudClimat
                        });
                    }
                    _startDate = _startDate.AddMinutes(1);
                    mnc = null;
                }
            };

            return _mTemp;
        }

        //by week
        public List<MesuresSensVentClimat> GetMesureSensVentByWeekByMinute(int idNoeudClimat, string startTime)
        {
            DateTime startDate = DateTime.ParseExact(startTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime endDate = startDate.AddDays(7);

            var mTemp1 = entities.mesure_noeudclimat.Where(x => x.mesure_noeud.FK_IdImplNoeud == idNoeudClimat);
            var mTemp = mTemp1.Where(x => (EntityFunctions.TruncateTime(x.mesure_noeud.DateMesureNoeud.Value) >= startDate.Date) && (EntityFunctions.TruncateTime(x.mesure_noeud.DateMesureNoeud.Value) <= endDate.Date));
            List<MesuresSensVentClimat> mTemp2 = mTemp.Select(x => new MesuresSensVentClimat
            {
                // delete millisecond fields from DateTime attribute
                DateMesure = EntityFunctions.AddSeconds(EntityFunctions.AddMilliseconds(x.mesure_noeud.DateMesureNoeud.Value, -x.mesure_noeud.DateMesureNoeud.Value.Millisecond).Value, -x.mesure_noeud.DateMesureNoeud.Value.Second).Value,
                IdMesureClimat = x.IdMesureNoeud,
                SensVentClimat = x.SensVent.Value,
                IdParentNode = x.mesure_noeud.FK_IdImplNoeud
            }).ToList();

            DateTime _startDate = startDate.Date;
            List<MesuresSensVentClimat> _mTemp = new List<MesuresSensVentClimat>();

            for (int k = 0; k < 7; k++)
            {
                for (int i = 0; i < 24; i++)
                {
                    for (var f = 0; f < 60; f++)
                    {
                        MesuresSensVentClimat mnc = new MesuresSensVentClimat();
                        mnc = mTemp2.FirstOrDefault(x => DateTime.Compare(x.DateMesure, _startDate) == 0);
                        if (mnc != null)
                        {
                            _mTemp.Add(mnc);
                        }
                        else
                        {
                            _mTemp.Add(new MesuresSensVentClimat
                            {
                                DateMesure = _startDate,
                                SensVentClimat = null,
                                IdParentNode = idNoeudClimat
                            });
                        }
                        _startDate = _startDate.AddMinutes(1);
                        mnc = null;
                    }
                }
            }

            return _mTemp;
        }

        //periode

        public List<MesuresSensVentClimat> GetMesuresSensVentByIdClimatByIntervalByMinute(int idNoeudClimat, string startTime, string endTime)
        {
            DateTime startDate = DateTime.ParseExact(startTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(endTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

            var mTemp1 = entities.mesure_noeudclimat.Where(x => x.mesure_noeud.FK_IdImplNoeud == idNoeudClimat);
            var mTemp = mTemp1.Where(x => x.mesure_noeud.DateMesureNoeud.Value >= startDate && x.mesure_noeud.DateMesureNoeud.Value <= endDate);
            List<MesuresSensVentClimat> mTemp2 = mTemp.Select(x => new MesuresSensVentClimat
            {
                // delete millisecond fields from DateTime attribute
                DateMesure = EntityFunctions.AddSeconds(EntityFunctions.AddMilliseconds(x.mesure_noeud.DateMesureNoeud.Value, -x.mesure_noeud.DateMesureNoeud.Value.Millisecond).Value, -x.mesure_noeud.DateMesureNoeud.Value.Second).Value,
                IdMesureClimat = x.IdMesureNoeud,
                SensVentClimat = x.SensVent.Value,
                IdParentNode = x.mesure_noeud.FK_IdImplNoeud
            }).ToList();

            List<MesuresSensVentClimat> _mTemp = new List<MesuresSensVentClimat>();
            TimeSpan ts = endDate - startDate;
            DateTime _startDate = startDate.Date;
            for (int j = 0; j < ts.Days; j++)
            {
                for (int i = 0; i < 24; i++)
                {
                    for (var f = 0; f < 60; f++)
                    {
                        MesuresSensVentClimat mnc = new MesuresSensVentClimat();
                        mnc = mTemp2.FirstOrDefault(x => DateTime.Compare(x.DateMesure, _startDate) == 0);
                        if (mnc != null)
                        {
                            _mTemp.Add(mnc);
                        }
                        else
                        {
                            _mTemp.Add(new MesuresSensVentClimat
                            {
                                DateMesure = _startDate,
                                SensVentClimat = null,
                                IdParentNode = idNoeudClimat
                            });
                        }
                        _startDate = _startDate.AddMinutes(1);
                        mnc = null;
                    }
                }
            }
            return _mTemp;
        }


        // ********************************************Get all mesures ********************************************************

        //one hour
        public List<MesuresClimatModel> GetMesureByIdClimatByMinute(int idNoeudClimat, string startTime)
        {
            DateTime startDate = DateTime.ParseExact(startTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime endDate = startDate.AddHours(1);

            var mTemp1 = entities.mesure_noeudclimat.Where(x => x.mesure_noeud.FK_IdImplNoeud == idNoeudClimat);
            var mTemp = mTemp1.Where(x => x.mesure_noeud.DateMesureNoeud.Value >= startDate && x.mesure_noeud.DateMesureNoeud.Value <= endDate);
            List<MesuresClimatModel> mTemp2 = mTemp.Select(x => new MesuresClimatModel
            {
                // delete millisecond fields from DateTime attribute
                DateMesure = EntityFunctions.AddSeconds(EntityFunctions.AddMilliseconds(x.mesure_noeud.DateMesureNoeud.Value, -x.mesure_noeud.DateMesureNoeud.Value.Millisecond).Value, -x.mesure_noeud.DateMesureNoeud.Value.Second).Value,
                IdMesureClimat = x.IdMesureNoeud,
                TemperatureClimat = x.TemperatureAir.Value,
                HumiditeClimat = x.HumiditeAir.Value,
                PluviometrieClimat = x.Pluviometrie.Value,
                RayonnementClimat = x.RayonnementSolaire.Value,
                VitesseVentClimat = x.VitesseVent.Value,
                SensVentClimat = x.SensVent.Value,
                IdParentNode = x.mesure_noeud.FK_IdImplNoeud
            }).ToList();

            DateTime _startDate = startDate;
            List<MesuresClimatModel> _mTemp = new List<MesuresClimatModel>();

            for (var f = 0; f < 60; f++)
            {
                MesuresClimatModel mnc = new MesuresClimatModel();
                mnc = mTemp2.FirstOrDefault(x => DateTime.Compare(x.DateMesure, _startDate) == 0);
                if (mnc != null)
                {
                    _mTemp.Add(mnc);
                }
                else
                {
                    _mTemp.Add(new MesuresClimatModel
                    {
                        DateMesure = _startDate,
                        TemperatureClimat = null,
                        HumiditeClimat = null,
                        PluviometrieClimat = null,
                        RayonnementClimat = null,
                        VitesseVentClimat = null,
                        SensVentClimat = null,
                        IdParentNode = idNoeudClimat
                    });
                }
                _startDate = _startDate.AddMinutes(1);
                mnc = null;
            }

            return _mTemp;
        }



        public List<MesuresClimatChoix> GetAllMesuresByIdClimatByDayByMinute(int idNoeudClimat, Boolean temp, Boolean hum, Boolean pluv, Boolean ray, Boolean vitessevent, Boolean sensvent)
        {
            DateTime startTime = new DateTime((DateTime.Now).Year, (DateTime.Now).Month, (DateTime.Now).Day);


            // mesures_climat = new AutoRefreshWrapper<mesure_noeudclimat>(entities.mesure_noeudclimat, RefreshMode.StoreWins);
            // extract all climate mesures related to one node
            var mTemp1 = entities.mesure_noeudclimat/*mesures_climat*/.Where(x => x.mesure_noeud.FK_IdImplNoeud == idNoeudClimat);
            // select from previous list mesures related to proposed day
            var mTemp = mTemp1.Where(x => EntityFunctions.TruncateTime(x.mesure_noeud.DateMesureNoeud.Value) == startTime.Date);
            //var mTemp = mTemp1.Where(x => x.mesure_noeud.DateMesureNoeud.Value.Date == startDate.Date);
            int nb = mTemp.Count();
            // fill 'MesuresTemperatureClimat' class with mesures from previous list
            List<MesuresClimatChoix> mTemp2 = mTemp.Select(x => new MesuresClimatChoix
            {
                // delete millisecond fields from DateTime attribute
                DateMesure = EntityFunctions.AddSeconds(EntityFunctions.AddMilliseconds(x.mesure_noeud.DateMesureNoeud.Value, -x.mesure_noeud.DateMesureNoeud.Value.Millisecond).Value, -x.mesure_noeud.DateMesureNoeud.Value.Second).Value,
                //DateMesure = x.mesure_noeud.DateMesureNoeud.Value.AddMilliseconds(-x.mesure_noeud.DateMesureNoeud.Value.Millisecond).AddSeconds(-x.mesure_noeud.DateMesureNoeud.Value.Second),
                IdMesureClimat = x.IdMesureNoeud,
                TemperatureClimat = temp ? x.TemperatureAir.Value : (float?)null,
                HumiditeClimat = hum ? x.HumiditeAir.Value : (float?)null,
                PluviometrieClimat = pluv ? x.Pluviometrie.Value : (float?)null,
                RayonnementClimat = ray ? x.RayonnementSolaire.Value : (float?)null,
                VitesseVentClimat = vitessevent ? x.VitesseVent.Value : (float?)null,
                SensVentClimat = sensvent ? x.SensVent.Value : (float?)null,
                IdParentNode = x.mesure_noeud.FK_IdImplNoeud,
                Temp_Etat = temp,
                Hum_Etat = hum,
                Pluv_Etat = pluv,
                Ray_Etat = ray,
                Vitesse_Etat = vitessevent,
                Sens_Etat = sensvent,
            }).ToList();

            DateTime _startDate = startTime.Date;
            List<MesuresClimatChoix> _mTemp = new List<MesuresClimatChoix>();

            if (mTemp.Count() == 0)
            {
                _mTemp.Add(new MesuresClimatChoix
                {
                    DateMesure = _startDate,
                    TemperatureClimat = null,
                    HumiditeClimat = null,
                    PluviometrieClimat = null,
                    RayonnementClimat = null,
                    VitesseVentClimat = null,
                    SensVentClimat = null,
                    IdParentNode = idNoeudClimat,
                    Temp_Etat = temp,
                    Hum_Etat = hum,
                    Pluv_Etat = pluv,
                    Ray_Etat = ray,
                    Vitesse_Etat = vitessevent,
                    Sens_Etat = sensvent,
                });
            }
            else
            {
                for (int i = 0; i < 24; i++)
                {
                    for (int f = 0; f < 60; f++)
                    {
                        MesuresClimatChoix mnc = new MesuresClimatChoix();
                        mnc = mTemp2.FirstOrDefault(x => DateTime.Compare(x.DateMesure, _startDate) == 0);
                        if (mnc != null)
                        {
                            _mTemp.Add(mnc);
                        }
                        else
                        {
                            _mTemp.Add(new MesuresClimatChoix
                            {
                                DateMesure = _startDate,
                                TemperatureClimat = null,
                                HumiditeClimat = null,
                                PluviometrieClimat = null,
                                RayonnementClimat = null,
                                VitesseVentClimat = null,
                                SensVentClimat = null,
                                IdParentNode = idNoeudClimat,
                                Temp_Etat = temp,
                                Hum_Etat = hum,
                                Pluv_Etat = pluv,
                                Ray_Etat = ray,
                                Vitesse_Etat = vitessevent,
                                Sens_Etat = sensvent,
                            });
                        }
                        _startDate = _startDate.AddMinutes(1);
                        mnc = null;
                    }

                };
            }

            return _mTemp;
        }

        public List<MesuresClimatModel> GetAllMesuresByIdClimatByDayByMinute(int idNoeudClimat, string startTime)
        {
            DateTime startDate;
            if (startTime.Length < 20) // c# time 05/09/2014 15:12:51
            {
                startDate = DateTime.ParseExact(startTime, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).Date;
            }
            else // js time
            {
                startDate = DateTime.ParseExact(startTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).Date;
            }

            // mesures_climat = new AutoRefreshWrapper<mesure_noeudclimat>(entities.mesure_noeudclimat, RefreshMode.StoreWins);
            // extract all climate mesures related to one node
            var mTemp1 = entities.mesure_noeudclimat/*mesures_climat*/.Where(x => x.mesure_noeud.FK_IdImplNoeud == idNoeudClimat);
            // select from previous list mesures related to proposed day
            var mTemp = mTemp1.Where(x => EntityFunctions.TruncateTime(x.mesure_noeud.DateMesureNoeud.Value) == startDate.Date);
            //var mTemp = mTemp1.Where(x => x.mesure_noeud.DateMesureNoeud.Value.Date == startDate.Date);
            int nb = mTemp.Count();

            // fill 'MesuresTemperatureClimat' class with mesures from previous list
            List<MesuresClimatModel> mTemp2 = mTemp.Select(x => new MesuresClimatModel
            {
                // delete millisecond fields from DateTime attribute
                DateMesure = EntityFunctions.AddSeconds(EntityFunctions.AddMilliseconds(x.mesure_noeud.DateMesureNoeud.Value, -x.mesure_noeud.DateMesureNoeud.Value.Millisecond).Value, -x.mesure_noeud.DateMesureNoeud.Value.Second).Value,
                //DateMesure = x.mesure_noeud.DateMesureNoeud.Value.AddMilliseconds(-x.mesure_noeud.DateMesureNoeud.Value.Millisecond).AddSeconds(-x.mesure_noeud.DateMesureNoeud.Value.Second),
                IdMesureClimat = x.IdMesureNoeud,
                TemperatureClimat = x.TemperatureAir.Value,
                HumiditeClimat = x.HumiditeAir.Value,
                PluviometrieClimat = x.Pluviometrie.Value,
                RayonnementClimat = x.RayonnementSolaire.Value,
                SensVentClimat = x.SensVent.Value,
                VitesseVentClimat = x.VitesseVent.Value,
                IdParentNode = x.mesure_noeud.FK_IdImplNoeud
            }).ToList();

            DateTime _startDate = startDate.Date;
            List<MesuresClimatModel> _mTemp = new List<MesuresClimatModel>();

            for (int i = 0; i < 24; i++)
            {
                for (int f = 0; f < 60; f++)
                {
                    MesuresClimatModel mnc = new MesuresClimatModel();
                    mnc = mTemp2.FirstOrDefault(x => DateTime.Compare(x.DateMesure, _startDate) == 0);
                    //System.Threading.Tasks.Task.Factory.StartNew(() =>
                    //{                     
                    //}).Wait();
                    if (mnc != null)
                    {
                        _mTemp.Add(mnc);
                    }
                    else
                    {
                        _mTemp.Add(new MesuresClimatModel
                        {
                            DateMesure = _startDate,
                            TemperatureClimat = null,
                            HumiditeClimat = null,
                            PluviometrieClimat = null,
                            RayonnementClimat = null,
                            SensVentClimat = null,
                            VitesseVentClimat = null,
                            IdParentNode = idNoeudClimat
                        });
                    }
                    _startDate = _startDate.AddMinutes(1);
                    mnc = null;
                }

                //System.Threading.Tasks.Parallel.For(0, 60, f =>
                //{
                //var mnc = mTemp2.FirstOrDefault(x => DateTime.Compare(x.DateMesure, _startDate) == 0);
                //if (mnc != null)
                //{
                //    _mTemp.Add(mnc);
                //}
                //else
                //{
                //    _mTemp.Add(new MesuresTemperatureClimat
                //    {
                //        DateMesure = _startDate,
                //        TemperatureClimat = null,
                //        IdParentNode = idNoeudClimat
                //    });
                //}
                //_startDate = _startDate.AddMinutes(1);
                //mnc = null;
                //});
            };

            return _mTemp;
        }

       
        //by week
        public List<MesuresClimatModel> GetMesureByWeekByMinute(int idNoeudClimat, string startTime)
        {
            DateTime startDate = DateTime.ParseExact(startTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime endDate = startDate.AddDays(7);

            var mTemp1 = entities.mesure_noeudclimat.Where(x => x.mesure_noeud.FK_IdImplNoeud == idNoeudClimat);
            var mTemp = mTemp1.Where(x => (EntityFunctions.TruncateTime(x.mesure_noeud.DateMesureNoeud.Value) >= startDate.Date) && (EntityFunctions.TruncateTime(x.mesure_noeud.DateMesureNoeud.Value) <= endDate.Date));
            List<MesuresClimatModel> mTemp2 = mTemp.Select(x => new MesuresClimatModel
            {
                // delete millisecond fields from DateTime attribute
                DateMesure = EntityFunctions.AddSeconds(EntityFunctions.AddMilliseconds(x.mesure_noeud.DateMesureNoeud.Value, -x.mesure_noeud.DateMesureNoeud.Value.Millisecond).Value, -x.mesure_noeud.DateMesureNoeud.Value.Second).Value,
                IdMesureClimat = x.IdMesureNoeud,
                TemperatureClimat = x.TemperatureAir.Value,
                HumiditeClimat = x.HumiditeAir.Value,
                PluviometrieClimat = x.Pluviometrie.Value,
                RayonnementClimat = x.RayonnementSolaire.Value,
                VitesseVentClimat = x.VitesseVent.Value,
                SensVentClimat = x.SensVent.Value,
                IdParentNode = x.mesure_noeud.FK_IdImplNoeud
            }).ToList();

            DateTime _startDate = startDate.Date;
            List<MesuresClimatModel> _mTemp = new List<MesuresClimatModel>();

            for (int k = 0; k < 7; k++)
            {
                for (int i = 0; i < 24; i++)
                {
                    for (var f = 0; f < 60; f++)
                    {
                        MesuresClimatModel mnc = new MesuresClimatModel();
                        mnc = mTemp2.FirstOrDefault(x => DateTime.Compare(x.DateMesure, _startDate) == 0);
                        if (mnc != null)
                        {
                            _mTemp.Add(mnc);
                        }
                        else
                        {
                            _mTemp.Add(new MesuresClimatModel
                            {
                                DateMesure = _startDate,
                                TemperatureClimat = null,
                                HumiditeClimat = null,
                                PluviometrieClimat = null,
                                RayonnementClimat = null,
                                VitesseVentClimat = null,
                                SensVentClimat = null,
                                IdParentNode = idNoeudClimat
                            });
                        }
                        _startDate = _startDate.AddMinutes(1);
                        mnc = null;
                    }
                }
            }

            return _mTemp;
        }

        //periode*
        public List<MesuresClimatModel> GetAllMesuresByIdClimatByIntervalByMinute(int idNoeudClimat, string startTime, string endTime)
        //public List<MesuresClimatModel> GetALLMesuresByIdClimatByIntervalByMinute(int idNoeudClimat, string startTime, string endTime)
        {
            DateTime startDate = DateTime.ParseExact(startTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(endTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

            var mTemp1 = entities.mesure_noeudclimat.Where(x => x.mesure_noeud.FK_IdImplNoeud == idNoeudClimat);
            var mTemp = mTemp1.Where(x => x.mesure_noeud.DateMesureNoeud.Value >= startDate && x.mesure_noeud.DateMesureNoeud.Value <= endDate);
            List<MesuresClimatModel> mTemp2 = mTemp.Select(x => new MesuresClimatModel
            {
                // delete millisecond fields from DateTime attribute
                DateMesure = EntityFunctions.AddSeconds(EntityFunctions.AddMilliseconds(x.mesure_noeud.DateMesureNoeud.Value, -x.mesure_noeud.DateMesureNoeud.Value.Millisecond).Value, -x.mesure_noeud.DateMesureNoeud.Value.Second).Value,
                IdMesureClimat = x.IdMesureNoeud,
                TemperatureClimat = x.TemperatureAir.Value,
                HumiditeClimat = x.HumiditeAir.Value,
                PluviometrieClimat = x.Pluviometrie.Value,
                RayonnementClimat = x.RayonnementSolaire.Value,
                VitesseVentClimat = x.VitesseVent.Value,
                SensVentClimat = x.SensVent.Value,
                IdParentNode = x.mesure_noeud.FK_IdImplNoeud
            }).ToList();

            List<MesuresClimatModel> _mTemp = new List<MesuresClimatModel>();
            TimeSpan ts = endDate - startDate;
            DateTime _startDate = startDate.Date;
            for (int j = 0; j < ts.Days; j++)
            {
                for (int i = 0; i < 24; i++)
                {
                    for (var f = 0; f < 60; f++)
                    {
                        MesuresClimatModel mnc = new MesuresClimatModel();
                        mnc = mTemp2.FirstOrDefault(x => DateTime.Compare(x.DateMesure, _startDate) == 0);
                        if (mnc != null)
                        {
                            _mTemp.Add(mnc);
                        }
                        else
                        {
                            _mTemp.Add(new MesuresClimatModel
                            {
                                DateMesure = _startDate,
                                TemperatureClimat = null,
                                HumiditeClimat = null,
                                PluviometrieClimat = null,
                                RayonnementClimat = null,
                                VitesseVentClimat = null,
                                SensVentClimat = null,
                                IdParentNode = idNoeudClimat
                            });
                        }
                        _startDate = _startDate.AddMinutes(1);
                        mnc = null;
                    }
                }
            }
            return _mTemp;
        }

        /*********************************************************************************************************/
        public List<MesuresMoyClimatModel> GetMesuresMoyClimatByIdExploitationOneWeek(int idExploit, string startTime)
        {
            DateTime startDate = DateTime.ParseExact(startTime.Remove(24), "ddd MMM dd yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            if (startDate.Day == DateTime.Now.Day)
            {
                startDate = startDate.AddDays(-7);
            }
            DateTime endDate = startDate.AddDays(7);

            bool test = false;
            var mesures = entities.mesure_noeudclimat_moyennes.Where(x => x.implanter_noeudclimat_exploitation.implanter_noeud_exploitation.secteur.parcelle.FK_IdExploitation == idExploit
                                                    && x.JourMesure >= startDate.Date
                                                    && x.JourMesure <= endDate.Date);

            List<MesuresMoyClimatModel> mesureList = new List<MesuresMoyClimatModel>();
            foreach (var mesure in mesures)
            {
                ////////////////////**********************************************************************////////////////
                double?
                    Rmoy = mesure.Rmoy,
                    Vmoy = mesure.Vvmoy,
                    ET0 = mesure.ET0;
                bool?
                    Rest = mesure.REst,
                    Vest = mesure.VEst;

                if (mesure.Rmoy == null)
                {
                    Rmoy = 0.19 * Math.Sqrt(mesure.TMax.Value - mesure.TMin.Value);
                    Rest = true;
                    mesure.Rmoy = (float)Math.Round(Rmoy.Value, 2);
                    mesure.REst = true;
                }
                if (mesure.Vvmoy == null)
                {
                    Vmoy = 2;
                    Vest = true;
                    mesure.Vvmoy = (float)Vmoy;
                    mesure.VEst = true;
                }
                if (mesure.ET0 == null)
                {
                    test = true;
                    double
                        psTmin = 0.6108 * Math.Exp(17.27 * mesure.TMin.Value / (mesure.TMin.Value + 237.3)),
                        psTmax = 0.6108 * Math.Exp(17.27 * mesure.TMax.Value / (mesure.TMax.Value + 237.3)),
                        ps = (psTmax - psTmin) / 2,
                        psTmoy = 0.6108 * Math.Exp(17.27 * mesure.TMoy.Value / (mesure.TMoy.Value + 237.3)),
                        gamma = 0.665 * Math.Pow(10, -3) * 101.3 * Math.Pow((293 - 0.0065 * 2) / 293, 5.26),
                        pente = 4099 * psTmoy / Math.Pow((mesure.TMoy.Value + 237.3), 2);

                    if (mesure.HMoy != null)
                    {
                        ps = (psTmax + psTmin) / 2 - (psTmin * (mesure.HMax.Value / 100) + psTmax * (mesure.HMin.Value / 100)) / 2;
                    }
                    ET0 = (0.408 * pente * Rmoy * (3600 * 24) / Math.Pow(10, 6) + gamma * 900 / (mesure.TMoy.Value + 273) * Vmoy * ps) / (pente + gamma * (1 + 0.34 * Vmoy));
                    mesure.ET0 = (float)Math.Round(ET0.Value, 2);
                }
                ////////////////////**********************************************************************////////////////

                mesureList.Add(new MesuresMoyClimatModel
                {
                    IdMesureMoyClimat = mesure.IdMesureMoyenne,
                    DateMesureMoy = mesure.JourMesure.Value,
                    Tmoy = mesure.TMoy,
                    Hmoy = mesure.HMoy,
                    Rmoy = (float)Math.Round(Rmoy.Value, 2),
                    Rest = Rest,
                    Vmoy = (float)Math.Round(Vmoy.Value, 2),
                    Vest = Vest,
                    ET0 = (float)Math.Round(ET0.Value, 2),
                    IdParentNode = mesure.FK_IdNoeudClimat,
                    IdExploitation = mesure.implanter_noeudclimat_exploitation.implanter_noeud_exploitation.secteur.parcelle.FK_IdExploitation
                });
            }

            if (mesures.Count() == 0)
            {
                mesureList.Add(new MesuresMoyClimatModel
                {
                    IdParentNode = idExploit
                });
            }

            //if (test)
            //{
            //    try
            //    {
            //        entities.SaveChanges();
            //    }
            //    catch (ApplicationException ex)
            //    {
            //        throw new ApplicationException(
            //            "An error occurred when saving changes.", ex);
            //    }
            //}
            return mesureList;
        }


        public List<MesuresMoyClimatModel> GetMesuresMoyClimatByIdExploitationOneMonth(int idExploit, string startTime)
        {
            List<MesuresMoyClimatModel> mesureList = new List<MesuresMoyClimatModel>();
            return mesureList;
        }
    }
    #endregion
}