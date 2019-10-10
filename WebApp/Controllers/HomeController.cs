using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Abstract;
using WebApp.Data;
using System.Web.Helpers;
using System.Web.SessionState;
using WebApp.Services;
namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        #region КОНСТРУКТОР
        private ILoshokRepository UserRepository;
        private IPostRepository PostsRepository;
        private ITweetsImgsRepository TweetsImgsRepository;
        private ISubscribersRepository SubscribersRepository;
        private IImgsRepository ImgsRepository;
        public HomeController()
        {
            UserRepository = new EfModelRepository();
            PostsRepository = new EfPostRepository();
            SubscribersRepository = new EfSubscribersRepository();
            ImgsRepository = new EfImgsRepository();
            TweetsImgsRepository = new EfTweetsImgsRepository();
        }
        #endregion

        public ActionResult Index()
        {
            SecurityService.Session = System.Web.HttpContext.Current.Session;
            SecurityService.Users = new EfModelRepository { };
            if (!SecurityService.IsAuthenticated)
            {
                return View();
            }
            else
             return RedirectToAction("Inbox");
        }

        #region USER_FUNC
        public ViewResult Inbox()
        {
            SecurityService.Session = System.Web.HttpContext.Current.Session;
            SecurityService.Users = new EfModelRepository { };
            if (SecurityService.IsAuthenticated)
            {
               


                ZablevaikiResponse User = UserRepository.GetBy(SecurityService.Session["UserId"].ToString());
                ZablevaikiResponseWP UserWP = new ZablevaikiResponseWP { };
                UserWP.USER = User;
                UserWP.UP = ImgsRepository.GetBy(SecurityService.Session["UserId"].ToString());



                List<Post> MyTweets = PostsRepository.GetBy(User.Login);
                List<int> TweeIDs = new List<int> { };
                foreach (var item in MyTweets)
                {
                    TweeIDs.Add(item.id);
                }
                List<TweetImg> imgs = TweetsImgsRepository.GetByMany(TweeIDs);


                UserWP.Imgs = imgs;
                UserWP.Tweets = MyTweets;
                return View("Inbox", UserWP);
            }
            else
                return View("Index");
        }

        public ActionResult Feed()
        {
            SecurityService.Session = System.Web.HttpContext.Current.Session;
            SecurityService.Users = new EfModelRepository { };
            if (!SecurityService.IsAuthenticated)
            {
                return RedirectToAction ("Index");
            }
            else
            {
                ZablevaikiResponse user = UserRepository.GetBy(SecurityService.Session["UserId"].ToString());
                List<Post> feed = new List<Post> { };
                List<Subscriber> subs = SubscribersRepository.GetBy((SecurityService.Session["UserId"].ToString()));
                List<string> authors = new List<string> { };
                foreach (var item in subs)
                {
                    authors.Add(item.target);
                }
                feed = PostsRepository.GetByMany(authors);
                List<int> TweeIDs = new List<int> { };
                foreach (var item in feed)
                {
                    TweeIDs.Add(item.id);
                }
                List<TweetImg> imgs = TweetsImgsRepository.GetByMany(TweeIDs);
                List<Img> Pics = ImgsRepository.GetByMany(authors);
                FeedPostModel FD = new FeedPostModel { };
                FD.FeedPost = feed;
                FD.FeedPic = Pics;
                FD.TweeImgs = imgs;
                return View("Feed", FD);
            }
        }

        public ActionResult AllUsers()
        {
            SecurityService.Session = System.Web.HttpContext.Current.Session;
            SecurityService.Users = new EfModelRepository { };
            if (!SecurityService.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            else
            {
                List<ZablevaikiResponse> AllU = UserRepository.GetAll();
                AllU.RemoveAll(x => x.Login == SecurityService.Session["UserId"].ToString());
                List <ZablevaikiResponse> Users = AllU;
                List<string> Auths = new List<string> { };
                foreach (var item in Users)
                {
                    Auths.Add(item.Login);
                }
                List<Img> Pics = ImgsRepository.GetByMany(Auths);
                UsersWP U = new Models.UsersWP { };
                U.Usrs = Users;
                U.Pics = Pics;
                return View("AllUsers", U);
            }
        }

        public ActionResult Exit()
        {
            SecurityService.Session = System.Web.HttpContext.Current.Session;
            SecurityService.Users = new EfModelRepository { };
            if (!SecurityService.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            else
            {
                SecurityService.Session = System.Web.HttpContext.Current.Session;
                Session.Abandon();
                return RedirectToAction("Index");
            }
        }

        public ViewResult Thanks()
        {
            ZablevaikiResponse test = new ZablevaikiResponse { };
            test.Name = "test";
            return View(test);
        }

        [HttpGet]
        public ActionResult PersTweet(string name)
        {
            SecurityService.Session = System.Web.HttpContext.Current.Session;
            SecurityService.Users = new EfModelRepository { };
            if (!SecurityService.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            else
            {
                SecurityService.Session = System.Web.HttpContext.Current.Session;
                SecurityService.Users = new EfModelRepository { };
                if (SecurityService.IsAuthenticated)
                {
                    PostsFromOne feed = new PostsFromOne();
                    feed.author = name.ToString();
                    List<ZablevaikiResponse> USERS = UserRepository.Loshki.ToList();
                    ZablevaikiResponse US = USERS.Find(x => x.Login == feed.author);


                    if (US == null)
                    {

                        return View("Index");

                    }
                    else
                    {
                        feed.Posts = PostsRepository.GetBy(feed.author);

                        List<int> TweeIDs = new List<int> { };
                        foreach (var item in feed.Posts)
                        {
                            TweeIDs.Add(item.id);
                        }
                        List<TweetImg> imgs = TweetsImgsRepository.GetByMany(TweeIDs);

                        feed.Ava = ImgsRepository.GetBy(feed.author).image;
                        feed.TweeImgs = imgs;

                        if (SubscribersRepository.GetSub(SecurityService.Session["UserId"].ToString(), feed.author) != null)
                            return View("PersTweetSub", feed);
                        else
                            return View("PersTweetNonSub", feed);
                    }
                }
                else
                    return View("Index");


            }
        }

        public ActionResult MyTweet()
        {
            SecurityService.Session = System.Web.HttpContext.Current.Session;
            SecurityService.Users = new EfModelRepository { };
            if (!SecurityService.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            else
            {
                PostsFromOne feed = new PostsFromOne();
                feed.author = System.Web.HttpContext.Current.Session["UserId"].ToString();
                feed.Posts = PostsRepository.GetBy(feed.author);
                return View("MineTweet", feed);
            }
        }

        [HttpGet]
        public ActionResult SubAdd(string n)
        {
            SecurityService.Session = System.Web.HttpContext.Current.Session;
            SecurityService.Users = new EfModelRepository { };
            if (!SecurityService.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            else
            {
                Subscriber Sub = new Subscriber();
                Sub.sub = System.Web.HttpContext.Current.Session["UserId"].ToString();
                Sub.target = n;
                SubscribersRepository.AddSub(Sub);
                //ZablevaikiResponse User = UserRepository.GetBy(SecurityService.Session["UserId"].ToString());
                return RedirectToAction("PersTweet", "Home", new { name = n });
            }
        }

        [HttpGet]
        public ActionResult SubDel(string n)
        {
            SecurityService.Session = System.Web.HttpContext.Current.Session;
            SecurityService.Users = new EfModelRepository { };
            if (!SecurityService.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            else
            {
                Subscriber Sub = new Subscriber();
                Sub.sub = System.Web.HttpContext.Current.Session["UserId"].ToString();
                Sub.target = n;
                Subscriber SubDel = SubscribersRepository.GetSub(Sub.sub, Sub.target);
                SubscribersRepository.DelSub(SubDel);

                return RedirectToAction("PersTweet", "Home", new { name = n });
            }
        }
        
        [HttpGet]
        public ActionResult Writer()
        {
            SecurityService.Session = System.Web.HttpContext.Current.Session;
            SecurityService.Users = new EfModelRepository { };
            if (!SecurityService.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            else
            {
                SecurityService.Session = System.Web.HttpContext.Current.Session;
                TweetWithImgs tweet = new TweetWithImgs();
                tweet.Tweet = new Post();
               // tweet.Imgs = new HttpPostedFileBase();
                tweet.Tweet.author = Session["UserId"].ToString();
                return View("Writer", tweet);
            }
        }

        [HttpPost]
        public ActionResult Writer(TweetWithImgs TweetWi)
        {
            SecurityService.Session = System.Web.HttpContext.Current.Session;
            SecurityService.Users = new EfModelRepository { };
            if (!SecurityService.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            else
            {
                if (ModelState.IsValid)
                // Нужно отправить данные нового гостя по электронной почте 
                // организатору вечеринки.
                {
                    SecurityService.Session = System.Web.HttpContext.Current.Session;

                    TweetWi.Tweet.author = Session["UserId"].ToString();
                    PostsRepository.CreatePost(TweetWi.Tweet);

                    if (TweetWi.Imgs.Count() > 0)
                    foreach (var img in TweetWi.Imgs)
                    {
                        TweetImg Pic = new TweetImg();
                        Pic.tweeID = TweetWi.Tweet.id;
                        Stream fileStream = img.InputStream;
                        var mStreamer = new MemoryStream();
                        mStreamer.SetLength(fileStream.Length);
                        fileStream.Read(mStreamer.GetBuffer(), 0, (int)fileStream.Length);
                        mStreamer.Seek(0, SeekOrigin.Begin);
                        byte[] fileBytes = mStreamer.GetBuffer();
                        //SecurityService.Session = System.Web.HttpContext.Current.Session;
                       // Img ImPic = new Img();
                       // ImPic.author = Session["UserId"].ToString();
                        Pic.image = fileBytes;
                        //ImgsRepository.AddImg(ImPic);
                        // Pic.image = 
                         TweetsImgsRepository.AddImg(Pic);
                    }
                    return RedirectToAction("Inbox");
                }
                else
                    // Обнаружена ошибка проверки достоверности
                    return View();
            }
        }

        [HttpGet]
        public ActionResult Imager()
        {
            SecurityService.Session = System.Web.HttpContext.Current.Session;
            SecurityService.Users = new EfModelRepository { };
            if (!SecurityService.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            else
            {
                Img Pic = ImgsRepository.GetBy(SecurityService.Session["UserId"].ToString());
                if (Pic == null)
                {
                    Pic.author = SecurityService.Session["UserId"].ToString();
                    Pic.image = new byte[] { 255 };
                }
                return View("Imager",Pic);
            }
        }

        [HttpPost]
        public ActionResult Imager(HttpPostedFileBase Pic)
        {
           


           
           // Pic.InputStream;
               
            
            SecurityService.Session = System.Web.HttpContext.Current.Session;
            SecurityService.Users = new EfModelRepository { };
            if (!SecurityService.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            else
            {
                if (ModelState.IsValid)
                // Нужно отправить данные нового гостя по электронной почте 
                // организатору вечеринки.
                {
                    Stream fileStream = Pic.InputStream;
                    var mStreamer = new MemoryStream();
                    mStreamer.SetLength(fileStream.Length);
                    fileStream.Read(mStreamer.GetBuffer(), 0, (int)fileStream.Length);
                    mStreamer.Seek(0, SeekOrigin.Begin);
                    byte[] fileBytes = mStreamer.GetBuffer();
                    SecurityService.Session = System.Web.HttpContext.Current.Session;
                    Img ImPic = new Img();
                    ImPic.author = Session["UserId"].ToString();
                    ImPic.image = fileBytes;
                    ImgsRepository.AddImg(ImPic);
                    return RedirectToAction("Inbox");
                }
                else
                    // Обнаружена ошибка проверки достоверности
                    return View();
            }
        }

        #endregion


        #region AUTHORIZ
        [HttpGet]
        public ActionResult AutoForm()
        {
            SecurityService.Session = System.Web.HttpContext.Current.Session;
            SecurityService.Users = new EfModelRepository { };
            if (!SecurityService.IsAuthenticated)
            {
                return View();

            }
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AutoForm(Autorize Guest)
        {
            SecurityService.Session = System.Web.HttpContext.Current.Session;
            SecurityService.Users = new EfModelRepository { };
            if (SecurityService.Authenticate(Guest.login, Guest.password))
            {
                ZablevaikiResponse User = UserRepository.GetBy(Guest.login);
                SecurityService.Login(User);

                if (SecurityService.IsAuthenticated)
                // Нужно отправить данные нового гостя по электронной почте 
                // организатору вечеринки.

                {

                    return RedirectToAction("Inbox");
                }
                else
                    // Обнаружена ошибка проверки достоверности
                    return View();
            }
            else
                // Обнаружена ошибка проверки достоверности
                return View();
        }
        #endregion

        #region REGISTR
        [HttpGet]
        public ActionResult RegForm()
        {
            SecurityService.Session = System.Web.HttpContext.Current.Session;
            SecurityService.Users = new EfModelRepository { };
            if (!SecurityService.IsAuthenticated)
            {
                return View();
            }
            else
                return RedirectToAction("Index");

        }

        [HttpPost]
        public ViewResult RegForm(ZablevaikiResponse guest)
        {
            SecurityService.Session = System.Web.HttpContext.Current.Session;
            SecurityService.Users = new EfModelRepository { };
            if (!SecurityService.IsAuthenticated)
            {
                if (ModelState.IsValid)
                // Нужно отправить данные нового гостя по электронной почте 
                // организатору вечеринки.
                {
                    UserRepository.CreateLoshok(guest);
                    return View("Thanks", guest);
                }
                else
                    // Обнаружена ошибка проверки достоверности
                    return View();

            }
            else
            {
                return View();
            }
        }
        #endregion
    }
}