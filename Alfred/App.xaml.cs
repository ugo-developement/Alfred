using log4net;
using log4net.Appender;
using log4net.Repository;
using ShowMeTheXAML;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Alfred
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static void Initialize(string logDirectory)
        {
            //get the current logging repository for this application 
            ILoggerRepository repository = LogManager.GetRepository();
            //get all of the appenders for the repository 
            IAppender[] appenders = repository.GetAppenders();
            //only change the file path on the 'FileAppenders' 
            foreach (IAppender appender in (from iAppender in appenders
                                            where iAppender is FileAppender
                                            select iAppender))
            {
                FileAppender fileAppender = appender as FileAppender;
                //set the path to your logDirectory using the original file name defined 
                //in configuration 
                fileAppender.File = Path.Combine(logDirectory, Path.GetFileName(fileAppender.File));
                //make sure to call fileAppender.ActivateOptions() to notify the logging 
                //sub system that the configuration for this appender has changed. 
                fileAppender.ActivateOptions();
            }
        }

        private static readonly ILog log = LogManager.GetLogger(typeof(App));

        protected override void OnStartup(StartupEventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
            Initialize(@"\Logs\logs.txt");
            log.Info("        =============  Started Logging  =============        ");
            XamlDisplay.Init();
            base.OnStartup(e);
        }
    }
}
