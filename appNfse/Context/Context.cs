using FirebirdSql.Data.FirebirdClient;
using Models.Cadastros;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.SIS;
using Models.MOV;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Infra.Base
{
    public class Context : DbContext
    {

        public static FbConnection connection
        {
            get
            {
                var x = System.Configuration.ConfigurationManager.ConnectionStrings["base"].ConnectionString;

                //FbConnectionStringBuilder b = new FbConnectionStringBuilder();
                ////b.ServerType = FbServerType.Default;
                //b.UserID = "SYSDBA";
                //b.Password = "masterkey";
                //b.Dialect = 3;
                //b.Database = "D:\\cafw.fdb";
                //b.Charset = "WIN1251";
                //b.Port = 3050;
                ////b.ClientLibrary = "fbembed.dll";
                return new FbConnection(x);
            }
        }

        public Context() : //base("name=base")
            base(connection, true)
        //base(new FbConnection(@"database=localhost:locatelli;Port=3051;user=sysdba;password=masterkey"), true)
        {
            Database.SetInitializer<Context>(null);
            Database.Initialize(false);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            base.Configuration.LazyLoadingEnabled = false;
            
            modelBuilder.Conventions.AddBefore<ForeignKeyIndexConvention>(new ForeignKeyNamingConvention());
        }

        #region Entidades tipo sistema
        public virtual DbSet<SIS_USUARIO> SIS_USUARIO { get; set; }
        public virtual DbSet<SIS_USUARIO_EMPRESA> SIS_USUARIO_EMPRESA { get; set; }
        public virtual DbSet<SIS_MENU> SIS_MENU { get; set; }
        #endregion

        #region Entidades tipo Cadastros        
        public virtual DbSet<CAD_EMPRESA> CAD_EMPRESA { get; set; }

        public virtual DbSet<CAD_APARTAMENTO> CAD_APARTAMENTO { get; set; }
        public virtual DbSet<CAD_PESSOA> CAD_PESSOA { get; set; }
        public virtual DbSet<CAD_VEICULO> CAD_VEICULO { get; set; }
        public virtual DbSet<CAD_TORRE> CAD_TORRE { get; set; }
        #endregion

        #region Entidades MOV
        public virtual DbSet<MOV_ENTRADA> MOV_ENTRADA { get; set; }
        #endregion

    }
}
