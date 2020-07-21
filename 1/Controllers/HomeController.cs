using UchetAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data.Entity;
using ClosedXML.Excel;

namespace UchetAuto.Controllers
{
    
    public class HomeController : Controller
    {
        public UchetAutoEntities db =new UchetAutoEntities();
        public ActionResult Index()
        {
            return View();
        }
        //НЕ ИСПОЛЬЗУЕТСЯ
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        //НЕ ИСПОЛЬЗУЕТСЯ
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Drivers()
        {
            List<Voditel> voditelList = new List<Voditel>();
            voditelList = db.Voditel.OrderBy(u=>u.LastName).ToList();
            ViewBag.vod = voditelList;

            List<Filial> filiallList = new List<Filial>();
            filiallList = db.Filial.ToList();
            ViewBag.fil = filiallList;

            SelectList fill = new SelectList(db.Filial, "IDFil", "Filial1");
            ViewBag.fil = fill;

            return View(voditelList);

        }

        //Вывод видов топлива
        public ActionResult Fuel()
        {
            List<Fuel> fuelList = new List<Fuel>();
            fuelList = db.Fuel.OrderBy(u => u.Fuel1).ToList();
            ViewBag.fuel = fuelList;
            return View(fuelList);

        }

        //Вывод типов двигателя
        public ActionResult TypeMotor()
        {
            List<TypeMotor> motorList = new List<TypeMotor>();
            motorList = db.TypeMotor.OrderBy(u => u.TypeMotor1).ToList();
            ViewBag.motor = motorList;
            return View(motorList);

        }

        //Вывод типов автомобиля
        public ActionResult TypeCar()
        {
            List<TypeCar> carList = new List<TypeCar>();
            carList = db.TypeCar.OrderBy(u => u.TypeCar1).ToList();
            ViewBag.car = carList;
            return View(carList);

        }

        //Вывод типов кузова автомобиля
        public ActionResult TypeCarBody()
        {
            List<TypeCarBody> bodyList = new List<TypeCarBody>();
            bodyList = db.TypeCarBody.OrderBy(u => u.TypeCarBody1).ToList();
            ViewBag.fuel = bodyList;
            return View(bodyList);

        }

        //Вывод подразделения
        public ActionResult Position()
        {
            List<Podrazd> podrazd = new List<Podrazd>();
            podrazd = db.Podrazd.OrderBy(u => u.Podrazd1).ToList();
            return View(podrazd);
        }

        //Вывод должностей
        public ActionResult Department()
        {
            List<Doljnost> dep = new List<Doljnost>();
            dep = db.Doljnost.OrderBy(u => u.Doljnost1).ToList();
            return View(dep);

        }

        //Добавить водителя//

        public ActionResult AddDriver()
        {
            List<Filial> filiallList = new List<Filial>();
            filiallList = db.Filial.ToList();
            ViewBag.fil = filiallList;

            SelectList fill = new SelectList(db.Filial, "IDFil", "Filial1");
            ViewBag.fil = fill;

            SelectList Podrazd = new SelectList(db.Podrazd, "IDPodr", "Podrazd1");
            ViewBag.podrazd = Podrazd;

            SelectList dolj = new SelectList(db.Doljnost, "IDDolj", "Doljnost1");
            ViewBag.dolj = dolj;

            return PartialView();
        }
        //--------------------------//

        public ActionResult support()
        {
            return PartialView();
        }

        //Сохранение водителя в базе данных//

        [HttpPost]
        public ActionResult DriverAddSave(string TabNumber, string LastName, string FirstName, string MiddleName, string dateroj, string MobPhone, string GorPhone, string dateMed, string Fil, string Podrazd, string Dolj, string Class, string IDNumber, string Seria, string Number, string Propiska, string Address, string Vidan, string SrokD, string NumberVod, string SrokDVodUd, string NumberVoen, string Zvanie, List<string> array)
        {
            try
            {
                Voditel vod = new Voditel();
                Passport pass = new Passport();
                VodUd VU = new VodUd();
                VoenBilet VB = new VoenBilet();

                vod.TabNumber = TabNumber.Trim();
                vod.LastName = LastName.Trim();
                vod.FirstName = FirstName.Trim();
                vod.MiddleName = MiddleName.Trim();
                pass.DatRoj = Convert.ToDateTime(dateroj);
                vod.PhoneMob = MobPhone.Trim();
                vod.PhoneGor = GorPhone.Trim();
                vod.MedKomis = Convert.ToDateTime(dateMed);
                vod.IDFil = Convert.ToInt32(Fil.Trim());
                if (Dolj=="")
                {
                    vod.IDDolj =null ;
                }
                else
                {
                  vod.IDDolj = Convert.ToInt32(Dolj.Trim());
                }    
                if (Podrazd=="")
                {
                    vod.IDPodr = null;
                }
                else
                {
                 vod.IDPodr = Convert.ToInt32(Podrazd.Trim());
                }  
                if(Class=="")
                {
                    vod.Klass = null;
                }
                else
                {
                vod.Klass = Convert.ToInt32(Class.Trim());
                }                
                pass.IDNumber = IDNumber.Trim();
                pass.Seria = Seria.Trim();
                pass.Number = Number.Trim();
                pass.Propis = Propiska.Trim();
                vod.Address = Address.Trim();
                pass.Vidan = Vidan.Trim();
                pass.Srok = Convert.ToDateTime(SrokD);
                VU.Number = NumberVod.Trim();
                VU.SrokD = Convert.ToDateTime(SrokDVodUd);
                VB.Number = NumberVoen = NumberVoen.Trim();
                VB.Zvanie = Zvanie.Trim();

                foreach (var item in array)
                {
                    if (item == "AM")
                    {
                        VU.AM = item;
                    }

                    if (item == "A")
                    {
                        VU.A = item;
                    }

                    if (item == "A1")
                    {
                        VU.A1 = item;
                    }

                    if (item == "B")
                    {
                        VU.B = item;
                    }

                    if (item == "C")
                    {
                        VU.C = item;
                    }

                    if (item == "D")
                    {
                        VU.D = item;
                    }

                    if (item == "BE")
                    {
                        VU.BE = item;
                    }

                    if (item == "CE")
                    {
                        VU.CE = item;
                    }

                    if (item == "DE")
                    {
                        VU.DE = item;
                    }

                    if (item == "F")
                    {
                        VU.F = item;
                    }

                    if (item == "I")
                    {
                        VU.I = item;
                    }
                }

                db.Passport.Add(pass);
                db.VodUd.Add(VU);
                db.VoenBilet.Add(VB);
                db.SaveChanges();

                vod.IDPass = pass.IDPas;
                vod.IDVodUd = VU.IDVUd;
                vod.IDVoen = VB.IDVoen;

                db.Voditel.Add(vod);
                db.SaveChanges();
                                
                
                ViewBag.Message = "Водитель "+vod.LastName+" добавлен";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }

        //----------------------------------//
        // удаление водителя//

        public ActionResult DeleteDriver(int ID)
        {
            Voditel vod = new Voditel();
            vod = db.Voditel.FirstOrDefault(a => a.IDVod == ID);

            SelectList fill = new SelectList(db.Filial, "IDFil", "Filial1");
            ViewBag.fil = fill; 

            return PartialView(vod);
        }
        //-----------------------------//

        // Подтверждение удаления водителя//
        public ActionResult DeleteDriverOK(int ID)
        {
            try
            {

                Voditel vod = new Voditel();
                vod = db.Voditel.FirstOrDefault(a => a.IDVod == ID);
                db.Voditel.Remove(vod);
                db.SaveChanges();

                ViewBag.Message = "водитель "+vod.LastName +" удален!";
            }
            catch
            {
                ViewBag.Message = "Ошибка удаления";
            }

            return PartialView();
        }


        // Редактирование водителя//
        public ActionResult DriverEdit(int ID)
        {
            Voditel vod = new Voditel();
            vod = db.Voditel.FirstOrDefault(a=>a.IDVod==ID);
            
            IEnumerable<Filial> fil = db.Filial;
            fil = db.Filial.OrderBy(x => x.Filial1).ToList();
            ViewBag.fil = fil;

            IEnumerable<Podrazd> podr = db.Podrazd;
            podr = db.Podrazd.OrderBy(x => x.Podrazd1).ToList();
            ViewBag.podrazd = podr;

            IEnumerable<Doljnost> dolj = db.Doljnost;
            dolj = db.Doljnost.OrderBy(x => x.Doljnost1).ToList();
            ViewBag.dolj = dolj;

            return PartialView(vod);
        }
        //-------------------------//
        //-Сохранение редактирования водителя--------------------//
        [HttpPost]
        public ActionResult DriverEditSave(int ID, int IDPAS, int IDVU, int IDVB, string TabNumber, string LastName, string FirstName, string MiddleName, string dateroj, string MobPhone, string GorPhone, string dateMed, string Fil, string Podrazd, string Doljnost, string Class, string IDNumber, string Seria, string Number, string Propiska, string Address, string Vidan, string SrokD, string NumberVod, string SrokDVodUd, string NumberVoen, string Zvanie, List<string> array)
        {
            try
            {
                Voditel vod = new Voditel();
                vod = db.Voditel.FirstOrDefault(s=>s.IDVod==ID);

                Passport pass = new Passport();
                pass = db.Passport.FirstOrDefault(f=>f.IDPas==IDPAS);

                VodUd VU = new VodUd();
                VU = db.VodUd.FirstOrDefault(g=>g.IDVUd==IDVU);
                                
                VoenBilet VB = new VoenBilet();
                VB = db.VoenBilet.FirstOrDefault(g => g.IDVoen == IDVB);

                vod.TabNumber = TabNumber.Trim();
                vod.LastName = LastName.Trim();
                vod.FirstName = FirstName.Trim();
                vod.MiddleName = MiddleName.Trim();
                pass.DatRoj = Convert.ToDateTime(dateroj);
                vod.PhoneMob = MobPhone.Trim();
                vod.PhoneGor = GorPhone.Trim();
                vod.MedKomis = Convert.ToDateTime(dateMed);
                vod.IDFil = Convert.ToInt32(Fil.Trim());
                if (Doljnost == "")
                {
                    vod.IDDolj = null;
                }
                else
                {
                    vod.IDDolj = Convert.ToInt32(Doljnost.Trim());
                }
                if (Podrazd == "")
                {
                    vod.IDPodr = null;
                }
                else
                {
                    vod.IDPodr = Convert.ToInt32(Podrazd.Trim());
                }
                if (Class == "")
                {
                    vod.Klass = null;
                }
                else
                {
                    vod.Klass = Convert.ToInt32(Class.Trim());
                }
                pass.IDNumber = IDNumber.Trim();
                pass.Seria = Seria.Trim();
                pass.Number = Number.Trim();
                pass.Propis = Propiska.Trim();
                vod.Address = Address.Trim();
                pass.Vidan = Vidan.Trim();
                pass.Srok = Convert.ToDateTime(SrokD);
                VU.Number = NumberVod.Trim();
                VU.SrokD = Convert.ToDateTime(SrokDVodUd);
                VB.Number = NumberVoen.Trim();
                VB.Zvanie = Zvanie.Trim();
                VU.AM = null;
                VU.A = null;
                VU.A1 = null;
                VU.B = null;
                VU.C = null;
                VU.D = null;
                VU.BE = null;
                VU.CE = null;
                VU.DE = null;
                VU.F = null;
                VU.I = null;

                foreach (var item in array)
                {
                    if (item == "AM")
                    {
                        VU.AM = item;
                    }

                    if (item == "A")
                    {
                        VU.A = item;
                    }

                    if (item == "A1")
                    {
                        VU.A1 = item;
                    }

                    if (item == "B")
                    {
                        VU.B = item;
                    }
                    
                    if (item == "C")
                    {
                        VU.C = item;
                    }
                    
                    if (item == "D")
                    {
                        VU.D = item;
                    }
                                        
                    if (item == "BE")
                    {
                        VU.BE = item;
                    }

                    if (item == "CE")
                    {
                        VU.CE = item;
                    }

                    if (item == "DE")
                    {
                        VU.DE = item;
                    }

                    if (item == "F")
                    {
                        VU.F = item;
                    }

                    if (item == "I")
                    {
                        VU.I = item;
                    }

                }

                //db.Passport.Add(pass);
                //db.VodUd.Add(VU);
                //db.VoenBilet.Add(VB);
                //db.SaveChanges();

                //vod.IDPass = pass.IDPas;
                //vod.IDVodUd = VU.IDVUd;
                //vod.IDVoen = VB.IDVoen;

                //db.Voditel.Add(vod);
                db.SaveChanges();


                ViewBag.Message = "Водитель " + vod.LastName + " изменён";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }


        //----------------------------------//
        //----------------------------------//

        public ActionResult Cars()
        {
            List<Cars> carList = new List<Cars>();
            carList = db.Cars.OrderBy(u => u.Model).ToList();
            ViewBag.car = carList;
            return View(carList);

        }
        //----------------------------------//
        //Добавить автомобиль//

        public ActionResult AddCar()
        {
            List<Filial> filiallList = new List<Filial>();
            filiallList = db.Filial.ToList();
            ViewBag.fil = filiallList;

            SelectList fill = new SelectList(db.Filial, "IDFil", "Filial1");
            ViewBag.fil = fill;

            SelectList vod = new SelectList(db.Voditel,"IDVod", "LastName");
            ViewBag.vod = vod;

            SelectList car = new SelectList(db.TypeCar, "IDTypeCar", "TypeCar1");
            ViewBag.car = car;

            SelectList body = new SelectList(db.TypeCarBody, "IDCarBody", "TypeCarBody1");
            ViewBag.body = body;

            SelectList motor = new SelectList(db.TypeMotor, "IDTypeMotor", "TypeMotor1");
            ViewBag.motor = motor;

            SelectList year = new SelectList(db.Year, "IDYear", "Year1");
            ViewBag.year = year;

            SelectList fuel = new SelectList(db.Fuel, "IDFuel", "Fuel1");
            ViewBag.fuel = fuel;

            return PartialView();
        }
        //--------------------------//
                
        //Сохранение автомобиля в базе данных//

        [HttpPost]
        public ActionResult CarAddSave(string GarNumber, string Model, string NumberGos, string vod, string Fil, string DatePost, string Tehosmotr, string car, string body, string motor, string year, string Gruzopod, string Whels, string Spare, string Odometer, string MotoHour, string fuel, string VMotor, string VTank, string BalanceTank, string LinNorma, string WithTrailer, string Na100TonnKm, string Mechanizm, string Heater, string Gorod100, string Gorod300, string Gorod1000, string WithStop, string Slowly, string Offroad, string Highway, string Amortiz, string Conditioning, string Generator, string AddBlue, string Career)
        {
            try
            {
                Cars carr = new Cars();

                carr.GarNumber = GarNumber.Trim();
                carr.Model = Model.Trim();
                carr.NumberCar = NumberGos.Trim();
                carr.IDDriver = Convert.ToInt32(vod.Trim());
                carr.IDFil = Convert.ToInt32(Fil.Trim());
                carr.DatePost = Convert.ToDateTime(DatePost);
                carr.Tehosmotr = Convert.ToDateTime(Tehosmotr);
                carr.IDTypeCar = Convert.ToInt32(car.Trim());
                carr.IDTypeCarBody = Convert.ToInt32(body.Trim());
                carr.IDTypeMotor = Convert.ToInt32(motor.Trim());
                carr.IDYear = Convert.ToInt32(year.Trim());
                carr.Gruzopod = Convert.ToDecimal(Gruzopod.Trim());
                carr.Whel = Convert.ToInt32(Whels.Trim());
                carr.Spare = Convert.ToInt32(Spare.Trim());
                carr.Odometer = Convert.ToDecimal(Odometer.Trim());
                if (MotoHour.Trim() == "")
                {
                    carr.MotoHour = null;
                }
                else
                {
                    carr.MotoHour = Convert.ToDecimal(MotoHour.Trim());
                }
                carr.IDFuel = Convert.ToInt32(fuel.Trim());
                carr.VTank = Convert.ToDecimal(VTank.Trim());

                if (VMotor.Trim() == "")
                {
                    carr.VMotor = null;
                }
                else
                {
                    carr.VMotor = Convert.ToDecimal(VMotor.Trim());
                }

                carr.BalanceTank = Convert.ToDecimal(BalanceTank.Trim());
                carr.LinNorma = Convert.ToDecimal(LinNorma.Trim());
                if (WithTrailer == "")
                {
                    carr.WithTrailer = null;
                }
                else
                {
                    carr.Na100TonnKm = Convert.ToDecimal(Na100TonnKm.Trim());
                }
                if (Mechanizm == "")
                {
                    carr.Mechanizm = null;
                }
                else
                {
                    carr.Mechanizm = Convert.ToDecimal(Mechanizm.Trim());
                }
                if (Heater == "")
                {
                    carr.Heater = null;
                }
                else
                {
                    carr.Heater = Convert.ToDecimal(Heater.Trim());
                }
                if (Gorod100 == "")
                {
                    carr.Gorod100 = null;
                }
                else
                {
                    carr.Gorod100 = Convert.ToDecimal(Gorod100.Trim());
                }
                if (Gorod300 == "")
                {
                    carr.Gorod300 = null;
                }
                else
                {
                    carr.Gorod300 = Convert.ToDecimal(Gorod300.Trim());
                }
                if (Gorod1000 == "")
                {
                    carr.Gorod1000 = null;
                }
                else
                {
                    carr.Gorod1000 = Convert.ToDecimal(Gorod1000.Trim());
                }
                if (WithStop == "")
                {
                    carr.WithStop = null;
                }
                else
                {
                    carr.WithStop = Convert.ToDecimal(WithStop.Trim());
                }
                if (Slowly == "")
                {
                    carr.Slowly = null;
                }
                else
                {
                    carr.Slowly = Convert.ToDecimal(Slowly.Trim());
                }
                if (Offroad == "")
                {
                    carr.Offroad = null;
                }
                else
                {
                    carr.Offroad = Convert.ToDecimal(Offroad.Trim());
                }
                if (Highway == "")
                {
                    carr.Highway = null;
                }
                else
                {
                    carr.Highway = Convert.ToDecimal(Highway.Trim());
                }
                if (Amortiz == "")
                {
                    carr.Amortiz = null;
                }
                else
                {
                    carr.Amortiz = Convert.ToDecimal(Amortiz.Trim());
                }
                if (Conditioning == "")
                {
                    carr.Conditioning = null;
                }
                else
                {
                    carr.Conditioning = Convert.ToDecimal(Conditioning.Trim());
                }
                if (Generator == "")
                {
                    carr.Generator = null;
                }
                else
                {
                    carr.Generator = Convert.ToDecimal(Generator.Trim());
                }
                if (AddBlue == "")
                {
                    carr.AddBlue = null;
                }
                else
                {
                    carr.AddBlue = Convert.ToDecimal(AddBlue.Trim());
                }
                if (Career == "")
                {
                    carr.Career = null;
                }
                else
                {
                    carr.Career = Convert.ToDecimal(Career.Trim());
                }

                db.Cars.Add(carr);                                
                db.SaveChanges();                           
                                
                ViewBag.Message = "Автомобиль " + carr.Model + " добавлен";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }

        //----------------------------------//
        // удаление автомобиля//

        public ActionResult DeleteCar(int ID)
        {
            Cars car = new Cars();
            car = db.Cars.FirstOrDefault(a => a.IDCar == ID);

            SelectList fill = new SelectList(db.Filial, "IDFil", "Filial1");
            ViewBag.fil = fill;

            List<Filial> filiallList = new List<Filial>();
            filiallList = db.Filial.ToList();
            ViewBag.fil = filiallList;

            

            

            return PartialView(car);
        }
        //-----------------------------//

        // Подтверждение удаления автомобиля//
        public ActionResult DeleteCarOK(int ID)
        {
            try
            {

                Cars carr = new Cars();
                carr = db.Cars.FirstOrDefault(a => a.IDCar == ID);
                db.Cars.Remove(carr);
                db.SaveChanges();

                ViewBag.Message = "Автомобиль " + carr.Model + " удален!";
            }
            catch
            {
                ViewBag.Message = "Ошибка удаления";
            }

            return PartialView();
        }


        // Редактирование автомобиля//
        public ActionResult CarEdit(int ID)
        {
            Cars car = new Cars();
            car = db.Cars.FirstOrDefault(a => a.IDCar == ID);

            IEnumerable<Cars> carr = db.Cars;
            carr = db.Cars.OrderBy(x => x.Model).ToList();
            ViewBag.vod = carr;

            //IEnumerable<Protocol> prot = db.Protocol;
            //prot = db.Protocol.OrderBy(x => x.Number).ToList();
            //ViewBag.prot = prot;
                                   
            //Zayavlenie zayav = new Zayavlenie();
            //zayav = db.Zayavlenie.FirstOrDefault(a => a.IDZ == ID);
            //return PartialView(zayav);

            IEnumerable<Filial> fill = db.Filial;
            fill = db.Filial.OrderBy(x => x.Filial1).ToList();
            ViewBag.fil = fill;

            IEnumerable<Voditel> vod = db.Voditel;
            vod = db.Voditel.OrderBy(x => x.LastName).ToList();
            ViewBag.vod = vod;

            IEnumerable<TypeCar> typecar = db.TypeCar;
            typecar = db.TypeCar.OrderBy(x => x.TypeCar1).ToList();
            ViewBag.typecar = typecar;

            IEnumerable<TypeCarBody> body = db.TypeCarBody;
            body = db.TypeCarBody.OrderBy(x => x.TypeCarBody1).ToList();
            ViewBag.body = body;

            IEnumerable<TypeMotor> motor = db.TypeMotor;
            motor = db.TypeMotor.OrderBy(x => x.TypeMotor1).ToList();
            ViewBag.motor = motor;

            IEnumerable<Year> year = db.Year;
            year = db.Year.OrderBy(x => x.Year1).ToList();
            ViewBag.year = year;

            IEnumerable<Fuel> fuel = db.Fuel;
            fuel = db.Fuel.OrderBy(x => x.Fuel1).ToList();
            ViewBag.fuel = fuel;

            
           return PartialView(car);


            //return PartialView(carr);
        }
        //-------------------------//
        //-Сохранение редактирования автомобиля--------------------//
        [HttpPost]
        public ActionResult CarEditSave(int ID, string GarNumber, string Model, string NumberGos, string vod, string Fil, string DatePost, string Tehosmotr, string car, string body, string motor, string year, string Gruzopod, string Whels, string Spare, string Odometer, string MotoHour, string fuel, string VMotor, string VTank, string BalanceTank, string LinNorma, string WithTrailer, string Na100TonnKm, string Mechanizm, string Heater, string Gorod100, string Gorod300, string Gorod1000, string WithStop, string Slowly, string Offroad, string Highway, string Amortiz, string Conditioning, string Generator, string AddBlue, string Career)
        {
            try
            {
                Cars carr = new Cars();                                
                carr = db.Cars.FirstOrDefault(s => s.IDCar == ID);
                
                carr.GarNumber = GarNumber.Trim();
                carr.Model = Model.Trim();
                carr.NumberCar = NumberGos.Trim();
                carr.IDDriver = Convert.ToInt32(vod.Trim());
                carr.IDFil = Convert.ToInt32(Fil.Trim());
                carr.DatePost = Convert.ToDateTime(DatePost);
                carr.Tehosmotr = Convert.ToDateTime(Tehosmotr);
                carr.IDTypeCar = Convert.ToInt32(car.Trim());
                carr.IDTypeCarBody = Convert.ToInt32(body.Trim());
                carr.IDTypeMotor = Convert.ToInt32(motor.Trim());
                carr.IDYear = Convert.ToInt32(year.Trim());
                carr.Gruzopod = Convert.ToDecimal(Gruzopod.Trim());
                carr.Whel = Convert.ToInt32(Whels.Trim());
                carr.Spare = Convert.ToInt32(Spare.Trim());
                carr.Odometer = Convert.ToDecimal(Odometer.Trim());
                if (MotoHour.Trim() == "")
                {
                    carr.MotoHour = null;
                }
                else
                {
                    carr.MotoHour = Convert.ToDecimal(MotoHour.Trim());
                }
                carr.IDFuel = Convert.ToInt32(fuel.Trim());

                if (VMotor.Trim() == "")
                {
                    carr.VMotor = null;
                }
                else
                {
                    carr.VMotor = Convert.ToDecimal(VMotor.Trim());
                }

                carr.VTank = Convert.ToDecimal(VTank.Trim());
                carr.BalanceTank = Convert.ToDecimal(BalanceTank.Trim());
                carr.LinNorma = Convert.ToDecimal(LinNorma.Trim());
                if (WithTrailer == "")
                {
                    carr.WithTrailer = null;
                }
                else
                {
                    carr.Na100TonnKm = Convert.ToDecimal(Na100TonnKm.Trim());
                }
                if (Mechanizm == "")
                {
                    carr.Mechanizm = null;
                }
                else
                {
                    carr.Mechanizm = Convert.ToDecimal(Mechanizm.Trim());
                }
                if (Heater == "")
                {
                    carr.Heater = null;
                }
                else
                {
                    carr.Heater = Convert.ToDecimal(Heater.Trim());
                }
                if (Gorod100 == "")
                {
                    carr.Gorod100 = null;
                }
                else
                {
                    carr.Gorod100 = Convert.ToDecimal(Gorod100.Trim());
                }
                if (Gorod300 == "")
                {
                    carr.Gorod300 = null;
                }
                else
                {
                    carr.Gorod300 = Convert.ToDecimal(Gorod300.Trim());
                }
                if (Gorod1000 == "")
                {
                    carr.Gorod1000 = null;
                }
                else
                {
                    carr.Gorod1000 = Convert.ToDecimal(Gorod1000.Trim());
                }
                if (WithStop == "")
                {
                    carr.WithStop = null;
                }
                else
                {
                    carr.WithStop = Convert.ToDecimal(WithStop.Trim());
                }
                if (Slowly == "")
                {
                    carr.Slowly = null;
                }
                else
                {
                    carr.Slowly = Convert.ToDecimal(Slowly.Trim());
                }
                if (Offroad == "")
                {
                    carr.Offroad = null;
                }
                else
                {
                    carr.Offroad = Convert.ToDecimal(Offroad.Trim());
                }
                if (Highway == "")
                {
                    carr.Highway = null;
                }
                else
                {
                    carr.Highway = Convert.ToDecimal(Highway.Trim());
                }
                if (Amortiz == "")
                {
                    carr.Amortiz = null;
                }
                else
                {
                    carr.Amortiz = Convert.ToDecimal(Amortiz.Trim());
                }
                if (Conditioning == "")
                {
                    carr.Conditioning = null;
                }
                else
                {
                    carr.Conditioning = Convert.ToDecimal(Conditioning.Trim());
                }
                if (Generator == "")
                {
                    carr.Generator = null;
                }
                else
                {
                    carr.Generator = Convert.ToDecimal(Generator.Trim());
                }
                if (AddBlue == "")
                {
                    carr.AddBlue = null;
                }
                else
                {
                    carr.AddBlue = Convert.ToDecimal(AddBlue.Trim());
                }
                if (Career == "")
                {
                    carr.Career = null;
                }
                else
                {
                    carr.Career = Convert.ToDecimal(Career.Trim());
                }

                //db.Cars.Add(carr);
                db.SaveChanges();

                ViewBag.Message = "Автомобиль " + carr.Model + " изменен";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }

        //---------------------------------//
        //------------СПРАВОЧНИКИ-------------------//

        //Добавить топливо//

        public ActionResult AddFuel()
        {
            
            return PartialView();
        }
        
        //Сохранение топлива в базе данных//

        [HttpPost]
        public ActionResult FuelAddSave(string Fuel, string Priznak)
        {
            try
            {
                Fuel fu = new Fuel();
                
                fu.Fuel1 = Fuel.Trim();
                if (Priznak == "")
                {
                    fu.Priznak = null;
                }
                else
                {
                    fu.Priznak = Priznak.Trim();
                }
                    
                db.Fuel.Add(fu);
                db.SaveChanges();


                ViewBag.Message = "Топливо " + fu.Fuel1 + " добавлено";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }

        //----------------------------------//
        // удаление топлива//

        public ActionResult DeleteFuel(int ID)
        {
            Fuel fu = new Fuel();
            fu = db.Fuel.FirstOrDefault(a => a.IDFuel == ID);
                       
            return PartialView(fu);
        }
        //-----------------------------//

        // Подтверждение удаления топлива//
        public ActionResult DeleteFuelOK(int ID)
        {
            try
            {

                Fuel fu = new Fuel();
                fu = db.Fuel.FirstOrDefault(a => a.IDFuel == ID);
                db.Fuel.Remove(fu);
                db.SaveChanges();

                ViewBag.Message = "Топливо " + fu.Fuel1 + " удалено!";
            }
            catch
            {
                ViewBag.Message = "Ошибка удаления";
            }

            return PartialView();
        }

        // удаление подразделения//

        public ActionResult DeletePodr(int ID)
        {
            Podrazd pod = new Podrazd();
            pod = db.Podrazd.FirstOrDefault(a => a.IDPodr == ID);

            return PartialView(pod);
        }
        //-----------------------------//

        // Подтверждение удаления подразделения//
        public ActionResult DeletePodrOK(int ID)
        {
            try
            {

                Podrazd pod = new Podrazd();
                pod = db.Podrazd.FirstOrDefault(a => a.IDPodr == ID);
                db.Podrazd.Remove(pod);
                db.SaveChanges();

                ViewBag.Message = "Подразделение " + pod.Podrazd1 + " удалено!";
            }
            catch
            {
                ViewBag.Message = "Ошибка удаления";
            }

            return PartialView();
        }

        // удаление должности//

        public ActionResult DeleteDolj(int ID)
        {
            Doljnost dol = new Doljnost();
            dol = db.Doljnost.FirstOrDefault(a => a.IDDolj == ID);

            return PartialView(dol);
        }
        //-----------------------------//

        // Подтверждение удаления топлива//
        public ActionResult DeleteDoljOK(int ID)
        {
            try
            {

                Doljnost dol = new Doljnost();
                dol = db.Doljnost.FirstOrDefault(a => a.IDDolj == ID);
                db.Doljnost.Remove(dol);
                db.SaveChanges();

                ViewBag.Message = "Должность " + dol.Doljnost1 + " удалена!";
            }
            catch
            {
                ViewBag.Message = "Ошибка удаления";
            }

            return PartialView();
        }

        // Редактирование топлива//
        public ActionResult FuelEdit(int ID)
        {
            Fuel fu = new Fuel();
            fu = db.Fuel.FirstOrDefault(a => a.IDFuel == ID);
                        
            return PartialView(fu);
        }
        //-------------------------//
        //-Сохранение редактирования топлива--------------------//
        [HttpPost]
        public ActionResult FuelEditSave(int ID,  string Fuel, string Priznak)
        {
            try
            {
                Fuel fu = new Fuel();
                fu = db.Fuel.FirstOrDefault(s => s.IDFuel == ID);

                fu.Fuel1 = Fuel.Trim();
                fu.Priznak = Priznak.Trim();
                               
                                
                db.SaveChanges();


                ViewBag.Message = "Топливо " + fu.Fuel1 + " изменёно";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }

        //----------------------------------//

        // Редактирование подразделения//
        public ActionResult PodrEdit(int ID)
        {
            Podrazd pod = new Podrazd();
            pod = db.Podrazd.FirstOrDefault(a => a.IDPodr == ID);

            IEnumerable<Filial> fil = db.Filial;
            fil = db.Filial.OrderBy(x => x.Filial1).ToList();
            ViewBag.fil = fil;

            return PartialView(pod);
        }
        //-------------------------//
        //-Сохранение редактирования подразделения--------------------//
        [HttpPost]
        public ActionResult PodrEditSave(int ID, string Podrazd, string Fil, string Priznak)
        {
            try
            {
                Podrazd pod = new Podrazd();
                pod = db.Podrazd.FirstOrDefault(s => s.IDPodr == ID);

                pod.Podrazd1 = Podrazd.Trim();
                pod.IDFilial = Convert.ToInt32(Fil.Trim());
                pod.Priznak = Priznak.Trim();


                db.SaveChanges();


                ViewBag.Message = "Подразделение " + pod.Podrazd1 + " изменёно";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }

        //----------------------------------//

        // Редактирование должности//
        public ActionResult DoljEdit(int ID)
        {
            Doljnost dol = new Doljnost();
            dol = db.Doljnost.FirstOrDefault(a => a.IDDolj == ID);

            return PartialView(dol);
        }
        //-------------------------//
        //-Сохранение редактирования должности--------------------//
        [HttpPost]
        public ActionResult DoljEditSave(int ID, string Doljnost, string Priznak)
        {
            try
            {
                Doljnost dol = new Doljnost();
                dol = db.Doljnost.FirstOrDefault(s => s.IDDolj == ID);

                dol.Doljnost1 = Doljnost.Trim();
                dol.Priznak = Priznak.Trim();


                db.SaveChanges();


                ViewBag.Message = "Должность " + dol.Doljnost1 + " изменёна";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }

        //----------------------------------//


        //Добавление типа автомобиля//

        public ActionResult AddTypeCar()
        {

            return PartialView();
        }

        //Сохранение типа автомобиля в базе данных//

        [HttpPost]
        public ActionResult TypeCarAddSave(string TypeCar, string Priznak)
        {
            try
            {
                TypeCar TC = new TypeCar();

                TC.TypeCar1 = TypeCar.Trim();
                if (Priznak == "")
                {
                    TC.Priznak = null;
                }
                else
                {
                    TC.Priznak = Priznak.Trim();
                }

                db.TypeCar.Add(TC);
                db.SaveChanges();


                ViewBag.Message = "Тип автомобиля " + TC.TypeCar1 + " добавлен";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }

        //----------------------------------//
        // удаление типа автомобиля//

        public ActionResult DeleteTypeCar(int ID)
        {
            TypeCar TC = new TypeCar();
            TC = db.TypeCar.FirstOrDefault(a => a.IDTypeCar == ID);

            return PartialView(TC);
        }
        //-----------------------------//

        // Подтверждение удаления типа автомобиля//
        public ActionResult DeleteTypeCarOK(int ID)
        {
            try
            {

                TypeCar TC = new TypeCar();
                TC = db.TypeCar.FirstOrDefault(a => a.IDTypeCar == ID);
                db.TypeCar.Remove(TC);
                db.SaveChanges();

                ViewBag.Message = "Тип автомобиля " + TC.TypeCar1 + " удален";
            }
            catch
            {
                ViewBag.Message = "Ошибка удаления";
            }

            return PartialView();
        }


        // Редактирование типа автомобиля//
        public ActionResult TypeCarEdit(int ID)
        {
            TypeCar TC = new TypeCar();
            TC = db.TypeCar.FirstOrDefault(a => a.IDTypeCar == ID);

            return PartialView(TC);
        }
        //-------------------------//
        //-Сохранение редактирования типа автомобиля--------------------//
        [HttpPost]
        public ActionResult TypeCarEditSave(int ID, string TypeCar, string Priznak)
        {
            try
            {
                TypeCar TC = new TypeCar();
                TC = db.TypeCar.FirstOrDefault(s => s.IDTypeCar == ID);

                TC.TypeCar1 = TypeCar.Trim();

                if (Priznak == "")
                {
                    TC.Priznak = null;
                }
                else
                {
                    TC.Priznak = Priznak.Trim();
                }


                db.SaveChanges();


                ViewBag.Message = "Тип автомобиля " + TC.TypeCar1 + " изменён";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }

        //----------------------------------//

        //Добавление типа кузова//

        public ActionResult AddTypeCarBody()
        {

            return PartialView();
        }

        //Сохранение типа кузова в базе данных//

        [HttpPost]
        public ActionResult TypeCarBodyAddSave(string TypeCarBody, string Priznak)
        {
            try
            {
                TypeCarBody TCB = new TypeCarBody();

                TCB.TypeCarBody1 = TypeCarBody.Trim();
                if (Priznak == "")
                {
                    TCB.Priznak = null;
                }
                else
                {
                    TCB.Priznak = Priznak.Trim();
                }

                db.TypeCarBody.Add(TCB);
                db.SaveChanges();


                ViewBag.Message = "Тип кузова " + TCB.TypeCarBody1 + " добавлен";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }

        //----------------------------------//

        //Добавление подразделения//

        public ActionResult AddPodr()
        {

            List<Filial> filiallList = new List<Filial>();
            filiallList = db.Filial.ToList();
            ViewBag.fil = filiallList;

            SelectList fill = new SelectList(db.Filial, "IDFil", "Filial1");
            ViewBag.fil = fill;

            return PartialView();
        }

        //Сохранение подразделения в базе данных//

        [HttpPost]
        public ActionResult PodrAddSave(string Podrazd, string Fil, string Priznak)
        {
            try
            {
               Podrazd pod = new Podrazd();
               pod.IDFilial = Convert.ToInt32(Fil.Trim());

                pod.Podrazd1 = Podrazd.Trim();
                if (Priznak == "")
                {
                    pod.Priznak = null;
                }
                else
                {
                    pod.Priznak = Priznak.Trim();
                }

                db.Podrazd.Add(pod);
                db.SaveChanges();


                ViewBag.Message = "Подразделение " + pod.Podrazd1 + " добавлено";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }

        //----------------------------------//

        //Добавление должности//

        public ActionResult AddDolj()
        {

            return PartialView();
        }

        //Сохранение должности в базе данных//

        [HttpPost]
        public ActionResult DoljAddSave(string Doljnost, string Priznak)
        {
            try
            {
                Doljnost dol = new Doljnost();
                
                dol.Doljnost1 = Doljnost.Trim();
                if (Priznak == "")
                {
                    dol.Priznak = null;
                }
                else
                {
                    dol.Priznak = Priznak.Trim();
                }

                db.Doljnost.Add(dol);
                db.SaveChanges();


                ViewBag.Message = "Должность " + dol.Doljnost1 + " добавлена";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }

        //----------------------------------//

        // удаление типа кузова//

        public ActionResult DeleteTypeCarBody(int ID)
        {
            TypeCarBody TCB = new TypeCarBody();
            TCB = db.TypeCarBody.FirstOrDefault(a => a.IDCarBody == ID);

            return PartialView(TCB);
        }
        //-----------------------------//

        // Подтверждение удаления типа кузова//
        public ActionResult DeleteTypeCarBodyOK(int ID)
        {
            try
            {

                TypeCarBody TCB = new TypeCarBody();
                TCB = db.TypeCarBody.FirstOrDefault(a => a.IDCarBody == ID);
                db.TypeCarBody.Remove(TCB);
                db.SaveChanges();

                ViewBag.Message = "Тип кузова " + TCB.TypeCarBody1 + " удален";
            }
            catch
            {
                ViewBag.Message = "Ошибка удаления";
            }

            return PartialView();
        }


        // Редактирование типа кузова//
        public ActionResult TypeCarBodyEdit(int ID)
        {
            TypeCarBody TCB = new TypeCarBody();
            TCB = db.TypeCarBody.FirstOrDefault(a => a.IDCarBody == ID);

            return PartialView(TCB);
        }
        //-------------------------//
        //-Сохранение редактирования типа кузова--------------------//
        [HttpPost]
        public ActionResult TypeCarBodyEditSave(int ID, string TypeCarBody, string Priznak)
        {
            try
            {
                TypeCarBody TCB = new TypeCarBody();
                TCB = db.TypeCarBody.FirstOrDefault(s => s.IDCarBody == ID);

                TCB.TypeCarBody1 = TypeCarBody.Trim();

                if (Priznak == "")
                {
                    TCB.Priznak = null;
                }
                else
                {
                    TCB.Priznak = Priznak.Trim();
                }


                db.SaveChanges();


                ViewBag.Message = "Тип кузова " + TCB.TypeCarBody1 + " изменён";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }

        //----------------------------------//

        //Добавление типа двигателя//

        public ActionResult AddTypeMotor()
        {

            return PartialView();
        }

        //Сохранение типа двигателя в базе данных//

        [HttpPost]
        public ActionResult TypeMotorAddSave(string TypeMotor, string Priznak)
        {
            try
            {
                TypeMotor TM = new TypeMotor();

                TM.TypeMotor1 = TypeMotor.Trim();
                if (Priznak == "")
                {
                    TM.Priznak = null;
                }
                else
                {
                    TM.Priznak = Priznak.Trim();
                }

                db.TypeMotor.Add(TM);
                db.SaveChanges();


                ViewBag.Message = "Тип двигателя " + TM.TypeMotor1 + " добавлен";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }

        //----------------------------------//
        // удаление типа двигателя//

        public ActionResult DeleteTypeMotor(int ID)
        {
            TypeMotor TM = new TypeMotor();
            TM = db.TypeMotor.FirstOrDefault(a => a.IDTypeMotor == ID);

            return PartialView(TM);
        }
        //-----------------------------//

        // Подтверждение удаления типа двигателя//
        public ActionResult DeleteTypeMotorOK(int ID)
        {
            try
            {

                TypeMotor TM = new TypeMotor();
                TM = db.TypeMotor.FirstOrDefault(a => a.IDTypeMotor == ID);
                db.TypeMotor.Remove(TM);
                db.SaveChanges();

                ViewBag.Message = "Тип двигателя " + TM.TypeMotor1 + " удален";
            }
            catch
            {
                ViewBag.Message = "Ошибка удаления";
            }

            return PartialView();
        }


        // Редактирование типа двигателя//
        public ActionResult TypeMotorEdit(int ID)
        {
            TypeMotor TM = new TypeMotor();
            TM = db.TypeMotor.FirstOrDefault(a => a.IDTypeMotor == ID);

            return PartialView(TM);
        }
        //-------------------------//
        //-Сохранение редактирования типа двигателя--------------------//
        [HttpPost]
        public ActionResult TypeMotorEditSave(int ID, string TypeMotor, string Priznak)
        {
            try
            {
                TypeMotor TM = new TypeMotor();
                TM = db.TypeMotor.FirstOrDefault(s => s.IDTypeMotor == ID);

                TM.TypeMotor1 = TypeMotor.Trim();

                if (Priznak == "")
                {
                    TM.Priznak = null;
                }
                else
                {
                    TM.Priznak = Priznak.Trim();
                }


                db.SaveChanges();


                ViewBag.Message = "Тип двигателя " + TM.TypeMotor1 + " изменён";
            }
            catch (Exception ex)
            {


                ViewBag.Message = ex.ToString();
            }

            return PartialView();
        }

        //----------Формирование отчета------------------------//

        public FileResult Export( )
        {

            List<Voditel> Vod = new List<Voditel>();
            Vod = db.Voditel.ToList();
            

            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Лист1");
            
            //Шапка отчета//

            worksheet.Cell("P" + 1).Value = "Открытое акционерное общество 'Гомельтранснефть Дружба'";
            worksheet.Cell("P" + 2).Value = "Филиал по транспортировке нефти 'Новополоцк'";
            worksheet.Cell("P" + 2).Style.Font.FontSize = 14;
            worksheet.Cell("P" + 1).Style.Font.FontSize = 14;
            worksheet.Cell("M" + 3).Style.Font.FontSize = 14;
            worksheet.Cell("M" + 3).Value = "";
            worksheet.Cell("M" + 4).Style.Font.FontSize = 14;
            worksheet.Cell("M" + 4).Value = "";
            worksheet.Cell("N" + 5).Style.Font.FontSize = 14;
            worksheet.Cell("N" + 5).Value = "";
            worksheet.Cell("P" + 6).Style.Font.FontSize = 14;
            worksheet.Cell("P" + 6).Value = "";
            worksheet.Cell("G" + 7).Style.Font.FontSize = 20;
            worksheet.Cell("G" + 7).Value = "Список водителей филиала";

            //создадим заголовки у столбцов
            worksheet.Cell("A" + 10).Value = "Таб.№";
            worksheet.Cell("B" + 10).Value = "Фамилия";
            worksheet.Cell("C" + 10).Value = "Имя";
            worksheet.Cell("D" + 10).Value = "Отчество";
            worksheet.Cell("E" + 10).Value = "Дата рожд.";
            worksheet.Cell("F" + 10).Value = "Моб.тел";
            worksheet.Cell("G" + 10).Value = "Гор.тел";
            worksheet.Cell("H" + 10).Value = "Мед.ком";
            worksheet.Cell("I" + 10).Value = "Филиал";
            worksheet.Cell("J" + 10).Value = "Подразд.";
            worksheet.Cell("K" + 10).Value = "Должность";
            worksheet.Cell("L" + 10).Value = "Класс";
            worksheet.Cell("M" + 10).Value = "№ пасп.";
            worksheet.Cell("N" + 10).Value = "Серия";
            worksheet.Cell("O" + 10).Value = "Номер";
            worksheet.Cell("P" + 10).Value = "Прописка";
            worksheet.Cell("Q" + 10).Value = "Проживание";
            worksheet.Cell("R" + 10).Value = "Выдан";
            worksheet.Cell("S" + 10).Value = "Срок действ.";
            worksheet.Cell("T" + 10).Value = "№ вод.уд.";
            worksheet.Cell("U" + 10).Value = "Срок действ.";
            worksheet.Cell("V" + 10).Value = "Категории";
            worksheet.Cell("W" + 10).Value = "№ воен.бил.";
            worksheet.Cell("X" + 10).Value = "Звание";


            for (int i = 0; i < Vod.Count; i++)
            {
                worksheet.Cell("A" + (i + 11)).Value = Vod[i].TabNumber; 
                worksheet.Cell("B" + (i + 11)).Value = Vod[i].LastName;
                worksheet.Cell("C" + (i + 11)).Value = Vod[i].FirstName;
                worksheet.Cell("D" + (i + 11)).Value = Vod[i].MiddleName;
                worksheet.Cell("E" + (i + 11)).Value = Vod[i].Passport.DatRoj;
                worksheet.Cell("F" + (i + 11)).Value = Vod[i].PhoneMob;
                worksheet.Cell("G" + (i + 11)).Value = Vod[i].PhoneGor;
                worksheet.Cell("H" + (i + 11)).Value = Vod[i].MedKomis;
                worksheet.Cell("I" + (i + 11)).Value = Vod[i].Filial.Filial1;
                if (Vod[i].Podrazd.Podrazd1 == null)
                {
                    worksheet.Cell("J" + (i + 11)).Value = "";
                } else
                {
                 worksheet.Cell("J" + (i + 11)).Value = Vod[i].Podrazd.Podrazd1;
                }
                if (Vod[i].Doljnost.Doljnost1 == null)
                {
                    worksheet.Cell("K" + (i + 11)).Value = "";
                }
                else
                {
                    worksheet.Cell("K" + (i + 11)).Value = Vod[i].Doljnost.Doljnost1;
                }
                if (Vod[i].Klass == null)
                {
                    worksheet.Cell("L" + (i + 11)).Value = "";
                }
                else
                {
                    worksheet.Cell("L" + (i + 11)).Value = Vod[i].Klass;
                }
                worksheet.Cell("M" + (i + 11)).Value = Vod[i].Passport.IDNumber;
                worksheet.Cell("N" + (i + 11)).Value = Vod[i].Passport.Seria;
                worksheet.Cell("O" + (i + 11)).Value = Vod[i].Passport.Number;
                worksheet.Cell("P" + (i + 11)).Value = Vod[i].Passport.Propis;
                worksheet.Cell("Q" + (i + 11)).Value = Vod[i].Address;
                worksheet.Cell("R" + (i + 11)).Value = Vod[i].Passport.Vidan;
                worksheet.Cell("S" + (i + 11)).Value = Vod[i].Passport.Srok;
                worksheet.Cell("T" + (i + 11)).Value = Vod[i].VodUd.Number;
                worksheet.Cell("U" + (i + 11)).Value = Vod[i].VodUd.SrokD;

                worksheet.Cell("V" + (i + 11)).Value = Vod[i].VodUd.A+ Vod[i].VodUd.A1+ Vod[i].VodUd.AM+ Vod[i].VodUd.B+ Vod[i].VodUd.C+ Vod[i].VodUd.D+ Vod[i].VodUd.BE+ Vod[i].VodUd.CE+ Vod[i].VodUd.DE+ Vod[i].VodUd.F+ Vod[i].VodUd.I;
                
                worksheet.Cell("W" + (i + 11)).Value = Vod[i].VoenBilet.Number;
                worksheet.Cell("X" + (i + 11)).Value = Vod[i].VoenBilet.Zvanie.Trim();
                

                worksheet.Cell("J" + (i + 11)).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                worksheet.Cell("R" + (i + 11)).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                worksheet.Cell("U" + (i + 11)).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                worksheet.Cell("w" + (i + 11)).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            }

            //пример изменения стиля ячейки
            worksheet.Cell("A" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("B" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("C" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("D" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("E" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("F" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("G" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("H" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("I" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("J" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("K" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("L" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("M" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("N" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("O" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("P" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("Q" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("R" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("S" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("T" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("U" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("V" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("W" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("X" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;


            var rngTable = worksheet.Range("A11:X" + (Vod.Count + 10));
            rngTable.Style.Border.RightBorder = XLBorderStyleValues.Thin;
            rngTable.Style.Border.BottomBorder = XLBorderStyleValues.Thin;


            //-------------------------------------------------//
            var rngTable111 = worksheet.Range("A10:x" + 10);
            rngTable111.Style.Border.RightBorder = XLBorderStyleValues.Medium;
            rngTable111.Style.Border.BottomBorder = XLBorderStyleValues.Medium;
            rngTable111.Style.Border.LeftBorder = XLBorderStyleValues.Medium;
            rngTable111.Style.Border.TopBorder = XLBorderStyleValues.Medium;
                        
            var col1 = worksheet.Column("E");
            col1.AdjustToContents();

            var col2 = worksheet.Column("A");
            col2.Width = 14;

            var col3 = worksheet.Column("B");
            col3.Width = 18;

            var col4 = worksheet.Column("C");
            col4.Width = 14;

            var col5 = worksheet.Column("F");
            col5.Width = 18;


            worksheet.Column(1).Style.Alignment.WrapText = true;
            worksheet.Column(2).Style.Alignment.WrapText = true;
            worksheet.Column(3).Style.Alignment.WrapText = true;
            worksheet.Column(4).Style.Alignment.WrapText = true;
            worksheet.Column(6).Style.Alignment.WrapText = true;

            // вернем пользователю файл без сохранения его на сервере
            using (MemoryStream stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Report.xlsx");
            }
        }



        //------------------Отчет согласно фильтра-------------------------//
        public ActionResult ReportFilter()
        {

            List<Filial> filiallList = new List<Filial>();
            filiallList = db.Filial.ToList();
            ViewBag.fil = filiallList;

            SelectList fill = new SelectList(db.Filial, "IDFil", "Filial1");
            ViewBag.fil = fill;

            SelectList Podrazd = new SelectList(db.Podrazd, "IDPodr", "Podrazd1");
            ViewBag.podrazd = Podrazd;

            SelectList dolj = new SelectList(db.Doljnost, "IDDolj", "Doljnost1");
            ViewBag.dolj = dolj;

            return PartialView();

        }
        //---------------------------------------------------------//
        //----------Просрочен паспорт------------------------//

        public FileResult ReportPassportEXCEL()
        {

            List<Voditel> Vod = new List<Voditel>();
            Vod = db.Voditel.Where(d=>d.Passport.Srok < DateTime.Now).ToList();


            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Лист1");

            //Шапка отчета//

            worksheet.Cell("P" + 1).Value = "Открытое акционерное общество 'Гомельтранснефть Дружба'";
            worksheet.Cell("P" + 2).Value = "Филиал по транспортировке нефти 'Новополоцк'";
            worksheet.Cell("P" + 2).Style.Font.FontSize = 14;
            worksheet.Cell("P" + 1).Style.Font.FontSize = 14;
            worksheet.Cell("M" + 3).Style.Font.FontSize = 14;
            worksheet.Cell("M" + 3).Value = "";
            worksheet.Cell("M" + 4).Style.Font.FontSize = 14;
            worksheet.Cell("M" + 4).Value = "";
            worksheet.Cell("N" + 5).Style.Font.FontSize = 14;
            worksheet.Cell("N" + 5).Value = "";
            worksheet.Cell("P" + 6).Style.Font.FontSize = 14;
            worksheet.Cell("P" + 6).Value = "";
            worksheet.Cell("G" + 7).Style.Font.FontSize = 20;
            worksheet.Cell("G" + 7).Value = "Список водителей у которых просрочен паспорт";

            //создадим заголовки у столбцов
            worksheet.Cell("A" + 10).Value = "Таб.№";
            worksheet.Cell("B" + 10).Value = "Фамилия";
            worksheet.Cell("C" + 10).Value = "Имя";
            worksheet.Cell("D" + 10).Value = "Отчество";
            worksheet.Cell("E" + 10).Value = "Дата рожд.";
            worksheet.Cell("F" + 10).Value = "Моб.тел";
            worksheet.Cell("G" + 10).Value = "Гор.тел";
            worksheet.Cell("H" + 10).Value = "Мед.ком";
            worksheet.Cell("I" + 10).Value = "Филиал";
            worksheet.Cell("J" + 10).Value = "Подразд.";
            worksheet.Cell("K" + 10).Value = "Должность";
            worksheet.Cell("L" + 10).Value = "Класс";
            worksheet.Cell("M" + 10).Value = "№ пасп.";
            worksheet.Cell("N" + 10).Value = "Серия";
            worksheet.Cell("O" + 10).Value = "Номер";
            worksheet.Cell("P" + 10).Value = "Прописка";
            worksheet.Cell("Q" + 10).Value = "Проживание";
            worksheet.Cell("R" + 10).Value = "Выдан";
            worksheet.Cell("S" + 10).Value = "Срок действ.";
            worksheet.Cell("T" + 10).Value = "№ вод.уд.";
            worksheet.Cell("U" + 10).Value = "Срок действ.";
            worksheet.Cell("V" + 10).Value = "Категории";
            worksheet.Cell("W" + 10).Value = "№ воен.бил.";
            worksheet.Cell("X" + 10).Value = "Звание";


            for (int i = 0; i < Vod.Count; i++)
            {
                if (Vod[i].Passport.Srok < DateTime.Now)
                {
                    worksheet.Cell("A" + (i + 11)).Value = Vod[i].TabNumber;
                    worksheet.Cell("B" + (i + 11)).Value = Vod[i].LastName;
                    worksheet.Cell("C" + (i + 11)).Value = Vod[i].FirstName;
                    worksheet.Cell("D" + (i + 11)).Value = Vod[i].MiddleName;
                    worksheet.Cell("E" + (i + 11)).Value = Vod[i].Passport.DatRoj;
                    worksheet.Cell("F" + (i + 11)).Value = Vod[i].PhoneMob;
                    worksheet.Cell("G" + (i + 11)).Value = Vod[i].PhoneGor;
                    worksheet.Cell("H" + (i + 11)).Value = Vod[i].MedKomis;
                    worksheet.Cell("I" + (i + 11)).Value = Vod[i].Filial.Filial1;
                    if (Vod[i].Podrazd.Podrazd1 == null)
                    {
                        worksheet.Cell("J" + (i + 11)).Value = "";
                    }
                    else
                    {
                        worksheet.Cell("J" + (i + 11)).Value = Vod[i].Podrazd.Podrazd1;
                    }
                    if (Vod[i].Doljnost.Doljnost1 == null)
                    {
                        worksheet.Cell("K" + (i + 11)).Value = "";
                    }
                    else
                    {
                        worksheet.Cell("K" + (i + 11)).Value = Vod[i].Doljnost.Doljnost1;
                    }
                    if (Vod[i].Klass == null)
                    {
                        worksheet.Cell("L" + (i + 11)).Value = "";
                    }
                    else
                    {
                        worksheet.Cell("L" + (i + 11)).Value = Vod[i].Klass;
                    }
                    worksheet.Cell("M" + (i + 11)).Value = Vod[i].Passport.IDNumber;
                    worksheet.Cell("N" + (i + 11)).Value = Vod[i].Passport.Seria;
                    worksheet.Cell("O" + (i + 11)).Value = Vod[i].Passport.Number;
                    worksheet.Cell("P" + (i + 11)).Value = Vod[i].Passport.Propis;
                    worksheet.Cell("Q" + (i + 11)).Value = Vod[i].Address;
                    worksheet.Cell("R" + (i + 11)).Value = Vod[i].Passport.Vidan;
                    worksheet.Cell("S" + (i + 11)).Value = Vod[i].Passport.Srok;
                    worksheet.Cell("T" + (i + 11)).Value = Vod[i].VodUd.Number;
                    worksheet.Cell("U" + (i + 11)).Value = Vod[i].VodUd.SrokD;

                    worksheet.Cell("V" + (i + 11)).Value = Vod[i].VodUd.A + Vod[i].VodUd.A1 + Vod[i].VodUd.AM + Vod[i].VodUd.B + Vod[i].VodUd.C + Vod[i].VodUd.D + Vod[i].VodUd.BE + Vod[i].VodUd.CE + Vod[i].VodUd.DE + Vod[i].VodUd.F + Vod[i].VodUd.I;

                    worksheet.Cell("W" + (i + 11)).Value = Vod[i].VoenBilet.Number;
                    worksheet.Cell("X" + (i + 11)).Value = Vod[i].VoenBilet.Zvanie.Trim();
                

                worksheet.Cell("J" + (i + 11)).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                worksheet.Cell("R" + (i + 11)).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                worksheet.Cell("U" + (i + 11)).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                worksheet.Cell("w" + (i + 11)).Style.Fill.BackgroundColor = XLColor.AliceBlue;
             
            

            //пример изменения стиля ячейки
            worksheet.Cell("A" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("B" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("C" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("D" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("E" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("F" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("G" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("H" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("I" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("J" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("K" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("L" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("M" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("N" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("O" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("P" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("Q" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("R" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("S" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("T" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("U" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("V" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("W" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
            worksheet.Cell("X" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;


            var rngTable = worksheet.Range("A11:X" + (Vod.Count + 10));
            rngTable.Style.Border.RightBorder = XLBorderStyleValues.Thin;
            rngTable.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
}
}
            //-------------------------------------------------//
            var rngTable111 = worksheet.Range("A10:x" + 10);
            rngTable111.Style.Border.RightBorder = XLBorderStyleValues.Medium;
            rngTable111.Style.Border.BottomBorder = XLBorderStyleValues.Medium;
            rngTable111.Style.Border.LeftBorder = XLBorderStyleValues.Medium;
            rngTable111.Style.Border.TopBorder = XLBorderStyleValues.Medium;

            var col1 = worksheet.Column("E");
            col1.AdjustToContents();

            var col2 = worksheet.Column("A");
            col2.Width = 14;

            var col3 = worksheet.Column("B");
            col3.Width = 18;

            var col4 = worksheet.Column("C");
            col4.Width = 14;

            var col5 = worksheet.Column("F");
            col5.Width = 18;


            worksheet.Column(1).Style.Alignment.WrapText = true;
            worksheet.Column(2).Style.Alignment.WrapText = true;
            worksheet.Column(3).Style.Alignment.WrapText = true;
            worksheet.Column(4).Style.Alignment.WrapText = true;
            worksheet.Column(6).Style.Alignment.WrapText = true;

            // вернем пользователю файл без сохранения его на сервере
            using (MemoryStream stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Report.xlsx");
            }
        }

        //----------Просрочено водительское удостоверение------------------------//

        public FileResult ReportVodUdEXCEL()
        {

            List<Voditel> Vod = new List<Voditel>();
            Vod = db.Voditel.Where(d=>d.VodUd.SrokD < DateTime.Now).ToList();


            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Лист1");

            //Шапка отчета//

            worksheet.Cell("P" + 1).Value = "Открытое акционерное общество 'Гомельтранснефть Дружба'";
            worksheet.Cell("P" + 2).Value = "";
            worksheet.Cell("P" + 2).Style.Font.FontSize = 14;
            worksheet.Cell("P" + 1).Style.Font.FontSize = 14;
            worksheet.Cell("M" + 3).Style.Font.FontSize = 14;
            worksheet.Cell("M" + 3).Value = "";
            worksheet.Cell("M" + 4).Style.Font.FontSize = 14;
            worksheet.Cell("M" + 4).Value = "";
            worksheet.Cell("N" + 5).Style.Font.FontSize = 14;
            worksheet.Cell("N" + 5).Value = "";
            worksheet.Cell("P" + 6).Style.Font.FontSize = 14;
            worksheet.Cell("P" + 6).Value = "";
            worksheet.Cell("G" + 7).Style.Font.FontSize = 20;
            worksheet.Cell("G" + 7).Value = "Список водителей у которых просрочено водительское удостоверение";

            //создадим заголовки у столбцов
            worksheet.Cell("A" + 10).Value = "Таб.№";
            worksheet.Cell("B" + 10).Value = "Фамилия";
            worksheet.Cell("C" + 10).Value = "Имя";
            worksheet.Cell("D" + 10).Value = "Отчество";
            worksheet.Cell("E" + 10).Value = "Дата рожд.";
            worksheet.Cell("F" + 10).Value = "Моб.тел";
            worksheet.Cell("G" + 10).Value = "Гор.тел";
            worksheet.Cell("H" + 10).Value = "Мед.ком";
            worksheet.Cell("I" + 10).Value = "Филиал";
            worksheet.Cell("J" + 10).Value = "Подразд.";
            worksheet.Cell("K" + 10).Value = "Должность";
            worksheet.Cell("L" + 10).Value = "Класс";
            worksheet.Cell("M" + 10).Value = "№ пасп.";
            worksheet.Cell("N" + 10).Value = "Серия";
            worksheet.Cell("O" + 10).Value = "Номер";
            worksheet.Cell("P" + 10).Value = "Прописка";
            worksheet.Cell("Q" + 10).Value = "Проживание";
            worksheet.Cell("R" + 10).Value = "Выдан";
            worksheet.Cell("S" + 10).Value = "Срок действ.";
            worksheet.Cell("T" + 10).Value = "№ вод.уд.";
            worksheet.Cell("U" + 10).Value = "Срок действ.";
            worksheet.Cell("V" + 10).Value = "Категории";
            worksheet.Cell("W" + 10).Value = "№ воен.бил.";
            worksheet.Cell("X" + 10).Value = "Звание";
                                   
               
                 for (int i = 0; i < Vod.Count; i++)
                        {
                    worksheet.Cell("A" + (i + 11)).Value = Vod[i].TabNumber;
                    worksheet.Cell("B" + (i + 11)).Value = Vod[i].LastName;
                    worksheet.Cell("C" + (i + 11)).Value = Vod[i].FirstName;
                    worksheet.Cell("D" + (i + 11)).Value = Vod[i].MiddleName;
                    worksheet.Cell("E" + (i + 11)).Value = Vod[i].Passport.DatRoj;
                    worksheet.Cell("F" + (i + 11)).Value = Vod[i].PhoneMob;
                    worksheet.Cell("G" + (i + 11)).Value = Vod[i].PhoneGor;
                    worksheet.Cell("H" + (i + 11)).Value = Vod[i].MedKomis;
                    worksheet.Cell("I" + (i + 11)).Value = Vod[i].Filial.Filial1;
                    if (Vod[i].Podrazd.Podrazd1 == null)
                    {
                        worksheet.Cell("J" + (i + 11)).Value = "";
                    }
                    else
                    {
                        worksheet.Cell("J" + (i + 11)).Value = Vod[i].Podrazd.Podrazd1;
                    }
                    if (Vod[i].Doljnost.Doljnost1 == null)
                    {
                        worksheet.Cell("K" + (i + 11)).Value = "";
                    }
                    else
                    {
                        worksheet.Cell("K" + (i + 11)).Value = Vod[i].Doljnost.Doljnost1;
                    }
                    if (Vod[i].Klass == null)
                    {
                        worksheet.Cell("L" + (i + 11)).Value = "";
                    }
                    else
                    {
                        worksheet.Cell("L" + (i + 11)).Value = Vod[i].Klass;
                    }
                    worksheet.Cell("M" + (i + 11)).Value = Vod[i].Passport.IDNumber;
                    worksheet.Cell("N" + (i + 11)).Value = Vod[i].Passport.Seria;
                    worksheet.Cell("O" + (i + 11)).Value = Vod[i].Passport.Number;
                    worksheet.Cell("P" + (i + 11)).Value = Vod[i].Passport.Propis;
                    worksheet.Cell("Q" + (i + 11)).Value = Vod[i].Address;
                    worksheet.Cell("R" + (i + 11)).Value = Vod[i].Passport.Vidan;
                    worksheet.Cell("S" + (i + 11)).Value = Vod[i].Passport.Srok;
                    worksheet.Cell("T" + (i + 11)).Value = Vod[i].VodUd.Number;
                    worksheet.Cell("U" + (i + 11)).Value = Vod[i].VodUd.SrokD;

                    worksheet.Cell("V" + (i + 11)).Value = Vod[i].VodUd.A + Vod[i].VodUd.A1 + Vod[i].VodUd.AM + Vod[i].VodUd.B + Vod[i].VodUd.C + Vod[i].VodUd.D + Vod[i].VodUd.BE + Vod[i].VodUd.CE + Vod[i].VodUd.DE + Vod[i].VodUd.F + Vod[i].VodUd.I;

                    worksheet.Cell("W" + (i + 11)).Value = Vod[i].VoenBilet.Number;
                    worksheet.Cell("X" + (i + 11)).Value = Vod[i].VoenBilet.Zvanie.Trim();


                    worksheet.Cell("J" + (i + 11)).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("R" + (i + 11)).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("U" + (i + 11)).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("w" + (i + 11)).Style.Fill.BackgroundColor = XLColor.AliceBlue;



                    //пример изменения стиля ячейки
                    worksheet.Cell("A" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("B" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("C" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("D" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("E" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("F" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("G" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("H" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("I" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("J" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("K" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("L" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("M" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("N" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("O" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("P" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("Q" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("R" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("S" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("T" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("U" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("V" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("W" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("X" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;


                    var rngTable = worksheet.Range("A11:X" + (Vod.Count + 10));
                    rngTable.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    rngTable.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                }
            
            //-------------------------------------------------//
            var rngTable111 = worksheet.Range("A10:x" + 10);
            rngTable111.Style.Border.RightBorder = XLBorderStyleValues.Medium;
            rngTable111.Style.Border.BottomBorder = XLBorderStyleValues.Medium;
            rngTable111.Style.Border.LeftBorder = XLBorderStyleValues.Medium;
            rngTable111.Style.Border.TopBorder = XLBorderStyleValues.Medium;

            var col1 = worksheet.Column("E");
            col1.AdjustToContents();

            var col2 = worksheet.Column("A");
            col2.Width = 14;

            var col3 = worksheet.Column("B");
            col3.Width = 18;

            var col4 = worksheet.Column("C");
            col4.Width = 14;

            var col5 = worksheet.Column("F");
            col5.Width = 18;


            worksheet.Column(1).Style.Alignment.WrapText = true;
            worksheet.Column(2).Style.Alignment.WrapText = true;
            worksheet.Column(3).Style.Alignment.WrapText = true;
            worksheet.Column(4).Style.Alignment.WrapText = true;
            worksheet.Column(6).Style.Alignment.WrapText = true;

            // вернем пользователю файл без сохранения его на сервере
            using (MemoryStream stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Report.xlsx");
            }
        }

        //----------не прошедшие медицинскую комиссию------------------------//

        public FileResult ReportMedEXCEL()
        {

            List<Voditel> Vod = new List<Voditel>();
            Vod = db.Voditel.Where(d=>d.MedKomis < DateTime.Now).ToList();


            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Лист1");

            //Шапка отчета//

            worksheet.Cell("P" + 1).Value = "Открытое акционерное общество 'Гомельтранснефть Дружба'";
            worksheet.Cell("P" + 2).Value = "";
            worksheet.Cell("P" + 2).Style.Font.FontSize = 14;
            worksheet.Cell("P" + 1).Style.Font.FontSize = 14;
            worksheet.Cell("M" + 3).Style.Font.FontSize = 14;
            worksheet.Cell("M" + 3).Value = "";
            worksheet.Cell("M" + 4).Style.Font.FontSize = 14;
            worksheet.Cell("M" + 4).Value = "";
            worksheet.Cell("N" + 5).Style.Font.FontSize = 14;
            worksheet.Cell("N" + 5).Value = "";
            worksheet.Cell("P" + 6).Style.Font.FontSize = 14;
            worksheet.Cell("P" + 6).Value = "";
            worksheet.Cell("G" + 7).Style.Font.FontSize = 20;
            worksheet.Cell("G" + 7).Value = "Список водителей не прошежших медицинскую комиссию";

            //создадим заголовки у столбцов
            worksheet.Cell("A" + 10).Value = "Таб.№";
            worksheet.Cell("B" + 10).Value = "Фамилия";
            worksheet.Cell("C" + 10).Value = "Имя";
            worksheet.Cell("D" + 10).Value = "Отчество";
            worksheet.Cell("E" + 10).Value = "Дата рожд.";
            worksheet.Cell("F" + 10).Value = "Моб.тел";
            worksheet.Cell("G" + 10).Value = "Гор.тел";
            worksheet.Cell("H" + 10).Value = "Мед.ком";
            worksheet.Cell("I" + 10).Value = "Филиал";
            worksheet.Cell("J" + 10).Value = "Подразд.";
            worksheet.Cell("K" + 10).Value = "Должность";
            worksheet.Cell("L" + 10).Value = "Класс";
            worksheet.Cell("M" + 10).Value = "№ пасп.";
            worksheet.Cell("N" + 10).Value = "Серия";
            worksheet.Cell("O" + 10).Value = "Номер";
            worksheet.Cell("P" + 10).Value = "Прописка";
            worksheet.Cell("Q" + 10).Value = "Проживание";
            worksheet.Cell("R" + 10).Value = "Выдан";
            worksheet.Cell("S" + 10).Value = "Срок действ.";
            worksheet.Cell("T" + 10).Value = "№ вод.уд.";
            worksheet.Cell("U" + 10).Value = "Срок действ.";
            worksheet.Cell("V" + 10).Value = "Категории";
            worksheet.Cell("W" + 10).Value = "№ воен.бил.";
            worksheet.Cell("X" + 10).Value = "Звание";


            for (int i = 0; i < Vod.Count; i++)
            {
                if (Vod[i].MedKomis < DateTime.Now)
                {
                    worksheet.Cell("A" + (i + 11)).Value = Vod[i].TabNumber;
                    worksheet.Cell("B" + (i + 11)).Value = Vod[i].LastName;
                    worksheet.Cell("C" + (i + 11)).Value = Vod[i].FirstName;
                    worksheet.Cell("D" + (i + 11)).Value = Vod[i].MiddleName;
                    worksheet.Cell("E" + (i + 11)).Value = Vod[i].Passport.DatRoj;
                    worksheet.Cell("F" + (i + 11)).Value = Vod[i].PhoneMob;
                    worksheet.Cell("G" + (i + 11)).Value = Vod[i].PhoneGor;
                    worksheet.Cell("H" + (i + 11)).Value = Vod[i].MedKomis;
                    worksheet.Cell("I" + (i + 11)).Value = Vod[i].Filial.Filial1;
                    if (Vod[i].Podrazd.Podrazd1 == null)
                    {
                        worksheet.Cell("J" + (i + 11)).Value = "";
                    }
                    else
                    {
                        worksheet.Cell("J" + (i + 11)).Value = Vod[i].Podrazd.Podrazd1;
                    }
                    if (Vod[i].Doljnost.Doljnost1 == null)
                    {
                        worksheet.Cell("K" + (i + 11)).Value = "";
                    }
                    else
                    {
                        worksheet.Cell("K" + (i + 11)).Value = Vod[i].Doljnost.Doljnost1;
                    }
                    if (Vod[i].Klass == null)
                    {
                        worksheet.Cell("L" + (i + 11)).Value = "";
                    }
                    else
                    {
                        worksheet.Cell("L" + (i + 11)).Value = Vod[i].Klass;
                    }
                    worksheet.Cell("M" + (i + 11)).Value = Vod[i].Passport.IDNumber;
                    worksheet.Cell("N" + (i + 11)).Value = Vod[i].Passport.Seria;
                    worksheet.Cell("O" + (i + 11)).Value = Vod[i].Passport.Number;
                    worksheet.Cell("P" + (i + 11)).Value = Vod[i].Passport.Propis;
                    worksheet.Cell("Q" + (i + 11)).Value = Vod[i].Address;
                    worksheet.Cell("R" + (i + 11)).Value = Vod[i].Passport.Vidan;
                    worksheet.Cell("S" + (i + 11)).Value = Vod[i].Passport.Srok;
                    worksheet.Cell("T" + (i + 11)).Value = Vod[i].VodUd.Number;
                    worksheet.Cell("U" + (i + 11)).Value = Vod[i].VodUd.SrokD;

                    worksheet.Cell("V" + (i + 11)).Value = Vod[i].VodUd.A + Vod[i].VodUd.A1 + Vod[i].VodUd.AM + Vod[i].VodUd.B + Vod[i].VodUd.C + Vod[i].VodUd.D + Vod[i].VodUd.BE + Vod[i].VodUd.CE + Vod[i].VodUd.DE + Vod[i].VodUd.F + Vod[i].VodUd.I;

                    worksheet.Cell("W" + (i + 11)).Value = Vod[i].VoenBilet.Number;
                    worksheet.Cell("X" + (i + 11)).Value = Vod[i].VoenBilet.Zvanie.Trim();


                    worksheet.Cell("J" + (i + 11)).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("R" + (i + 11)).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("U" + (i + 11)).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("w" + (i + 11)).Style.Fill.BackgroundColor = XLColor.AliceBlue;


                    //пример изменения стиля ячейки
                    worksheet.Cell("A" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("B" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("C" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("D" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("E" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("F" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("G" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("H" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("I" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("J" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("K" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("L" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("M" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("N" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("O" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("P" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("Q" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("R" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("S" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("T" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("U" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("V" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("W" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                    worksheet.Cell("X" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;


                    var rngTable = worksheet.Range("A11:X" + (Vod.Count + 10));
                    rngTable.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    rngTable.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
             
            //-------------------------------------------------//
            var rngTable111 = worksheet.Range("A10:x" + 10);
            rngTable111.Style.Border.RightBorder = XLBorderStyleValues.Medium;
            rngTable111.Style.Border.BottomBorder = XLBorderStyleValues.Medium;
            rngTable111.Style.Border.LeftBorder = XLBorderStyleValues.Medium;
            rngTable111.Style.Border.TopBorder = XLBorderStyleValues.Medium;

            var col1 = worksheet.Column("E");
            col1.AdjustToContents();

            var col2 = worksheet.Column("A");
            col2.Width = 14;

            var col3 = worksheet.Column("B");
            col3.Width = 18;

            var col4 = worksheet.Column("C");
            col4.Width = 14;

            var col5 = worksheet.Column("F");
            col5.Width = 18;


            worksheet.Column(1).Style.Alignment.WrapText = true;
            worksheet.Column(2).Style.Alignment.WrapText = true;
            worksheet.Column(3).Style.Alignment.WrapText = true;
            worksheet.Column(4).Style.Alignment.WrapText = true;
            worksheet.Column(6).Style.Alignment.WrapText = true;

}   
            }


            // вернем пользователю файл без сохранения его на сервере
            using (MemoryStream stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Report.xlsx");
            }
        }

        //----------Список водителей согласно фильтра------------------------//

        public FileResult ReportFilterExcel(int Fil)
        {

            List<Voditel> Vod = new List<Voditel>();
            Vod = db.Voditel.Where(d => d.IDFil == Fil).ToList();


            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Лист1");

            //Шапка отчета//

            worksheet.Cell("P" + 1).Value = "Открытое акционерное общество 'Гомельтранснефть Дружба'";
            worksheet.Cell("P" + 2).Value = "";
            worksheet.Cell("P" + 2).Style.Font.FontSize = 14;
            worksheet.Cell("P" + 1).Style.Font.FontSize = 14;
            worksheet.Cell("M" + 3).Style.Font.FontSize = 14;
            worksheet.Cell("M" + 3).Value = "";
            worksheet.Cell("M" + 4).Style.Font.FontSize = 14;
            worksheet.Cell("M" + 4).Value = "";
            worksheet.Cell("N" + 5).Style.Font.FontSize = 14;
            worksheet.Cell("N" + 5).Value = "";
            worksheet.Cell("P" + 6).Style.Font.FontSize = 14;
            worksheet.Cell("P" + 6).Value = "";
            worksheet.Cell("G" + 7).Style.Font.FontSize = 20;
            worksheet.Cell("G" + 7).Value = "Список водителей филиала "+ Fil;

            //создадим заголовки у столбцов
            worksheet.Cell("A" + 10).Value = "Таб.№";
            worksheet.Cell("B" + 10).Value = "Фамилия";
            worksheet.Cell("C" + 10).Value = "Имя";
            worksheet.Cell("D" + 10).Value = "Отчество";
            worksheet.Cell("E" + 10).Value = "Дата рожд.";
            worksheet.Cell("F" + 10).Value = "Моб.тел";
            worksheet.Cell("G" + 10).Value = "Гор.тел";
            worksheet.Cell("H" + 10).Value = "Мед.ком";
            worksheet.Cell("I" + 10).Value = "Филиал";
            worksheet.Cell("J" + 10).Value = "Подразд.";
            worksheet.Cell("K" + 10).Value = "Должность";
            worksheet.Cell("L" + 10).Value = "Класс";
            worksheet.Cell("M" + 10).Value = "№ пасп.";
            worksheet.Cell("N" + 10).Value = "Серия";
            worksheet.Cell("O" + 10).Value = "Номер";
            worksheet.Cell("P" + 10).Value = "Прописка";
            worksheet.Cell("Q" + 10).Value = "Проживание";
            worksheet.Cell("R" + 10).Value = "Выдан";
            worksheet.Cell("S" + 10).Value = "Срок действ.";
            worksheet.Cell("T" + 10).Value = "№ вод.уд.";
            worksheet.Cell("U" + 10).Value = "Срок действ.";
            worksheet.Cell("V" + 10).Value = "Категории";
            worksheet.Cell("W" + 10).Value = "№ воен.бил.";
            worksheet.Cell("X" + 10).Value = "Звание";


            for (int i = 0; i < Vod.Count; i++)
            {
                worksheet.Cell("A" + (i + 11)).Value = Vod[i].TabNumber;
                worksheet.Cell("B" + (i + 11)).Value = Vod[i].LastName;
                worksheet.Cell("C" + (i + 11)).Value = Vod[i].FirstName;
                worksheet.Cell("D" + (i + 11)).Value = Vod[i].MiddleName;
                worksheet.Cell("E" + (i + 11)).Value = Vod[i].Passport.DatRoj;
                worksheet.Cell("F" + (i + 11)).Value = Vod[i].PhoneMob;
                worksheet.Cell("G" + (i + 11)).Value = Vod[i].PhoneGor;
                worksheet.Cell("H" + (i + 11)).Value = Vod[i].MedKomis;
                worksheet.Cell("I" + (i + 11)).Value = Vod[i].Filial.Filial1;
                if (Vod[i].Podrazd.Podrazd1 == null)
                {
                    worksheet.Cell("J" + (i + 11)).Value = "";
                }
                else
                {
                    worksheet.Cell("J" + (i + 11)).Value = Vod[i].Podrazd.Podrazd1;
                }
                if (Vod[i].Doljnost.Doljnost1 == null)
                {
                    worksheet.Cell("K" + (i + 11)).Value = "";
                }
                else
                {
                    worksheet.Cell("K" + (i + 11)).Value = Vod[i].Doljnost.Doljnost1;
                }
                if (Vod[i].Klass == null)
                {
                    worksheet.Cell("L" + (i + 11)).Value = "";
                }
                else
                {
                    worksheet.Cell("L" + (i + 11)).Value = Vod[i].Klass;
                }
                worksheet.Cell("M" + (i + 11)).Value = Vod[i].Passport.IDNumber;
                worksheet.Cell("N" + (i + 11)).Value = Vod[i].Passport.Seria;
                worksheet.Cell("O" + (i + 11)).Value = Vod[i].Passport.Number;
                worksheet.Cell("P" + (i + 11)).Value = Vod[i].Passport.Propis;
                worksheet.Cell("Q" + (i + 11)).Value = Vod[i].Address;
                worksheet.Cell("R" + (i + 11)).Value = Vod[i].Passport.Vidan;
                worksheet.Cell("S" + (i + 11)).Value = Vod[i].Passport.Srok;
                worksheet.Cell("T" + (i + 11)).Value = Vod[i].VodUd.Number;
                worksheet.Cell("U" + (i + 11)).Value = Vod[i].VodUd.SrokD;

                worksheet.Cell("V" + (i + 11)).Value = Vod[i].VodUd.A + Vod[i].VodUd.A1 + Vod[i].VodUd.AM + Vod[i].VodUd.B + Vod[i].VodUd.C + Vod[i].VodUd.D + Vod[i].VodUd.BE + Vod[i].VodUd.CE + Vod[i].VodUd.DE + Vod[i].VodUd.F + Vod[i].VodUd.I;

                worksheet.Cell("W" + (i + 11)).Value = Vod[i].VoenBilet.Number;
                worksheet.Cell("X" + (i + 11)).Value = Vod[i].VoenBilet.Zvanie.Trim();


                worksheet.Cell("J" + (i + 11)).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                worksheet.Cell("R" + (i + 11)).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                worksheet.Cell("U" + (i + 11)).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                worksheet.Cell("w" + (i + 11)).Style.Fill.BackgroundColor = XLColor.AliceBlue;



                //пример изменения стиля ячейки
                worksheet.Cell("A" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                worksheet.Cell("B" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                worksheet.Cell("C" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                worksheet.Cell("D" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                worksheet.Cell("E" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                worksheet.Cell("F" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                worksheet.Cell("G" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                worksheet.Cell("H" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                worksheet.Cell("I" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                worksheet.Cell("J" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                worksheet.Cell("K" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                worksheet.Cell("L" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                worksheet.Cell("M" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                worksheet.Cell("N" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                worksheet.Cell("O" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                worksheet.Cell("P" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                worksheet.Cell("Q" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                worksheet.Cell("R" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                worksheet.Cell("S" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                worksheet.Cell("T" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                worksheet.Cell("U" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                worksheet.Cell("V" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                worksheet.Cell("W" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;
                worksheet.Cell("X" + 10).Style.Fill.BackgroundColor = XLColor.AliceBlue;


                var rngTable = worksheet.Range("A11:X" + (Vod.Count + 10));
                rngTable.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                rngTable.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            }

            //-------------------------------------------------//
            var rngTable111 = worksheet.Range("A10:x" + 10);
            rngTable111.Style.Border.RightBorder = XLBorderStyleValues.Medium;
            rngTable111.Style.Border.BottomBorder = XLBorderStyleValues.Medium;
            rngTable111.Style.Border.LeftBorder = XLBorderStyleValues.Medium;
            rngTable111.Style.Border.TopBorder = XLBorderStyleValues.Medium;

            var col1 = worksheet.Column("E");
            col1.AdjustToContents();

            var col2 = worksheet.Column("A");
            col2.Width = 14;

            var col3 = worksheet.Column("B");
            col3.Width = 18;

            var col4 = worksheet.Column("C");
            col4.Width = 14;

            var col5 = worksheet.Column("F");
            col5.Width = 18;


            worksheet.Column(1).Style.Alignment.WrapText = true;
            worksheet.Column(2).Style.Alignment.WrapText = true;
            worksheet.Column(3).Style.Alignment.WrapText = true;
            worksheet.Column(4).Style.Alignment.WrapText = true;
            worksheet.Column(6).Style.Alignment.WrapText = true;

            // вернем пользователю файл без сохранения его на сервере
            using (MemoryStream stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Report.xlsx");
            }
        }


    }
}