using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class aattractionlistcategorynovacios : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("TravelAgency", true);
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public aattractionlistcategorynovacios( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TravelAgency", true);
      }

      public aattractionlistcategorynovacios( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         setOutputFileName("AttractionList.pdf");
         setOutputType("pdf");
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 11909, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            H0S0( false, 135) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 14, false, false, false, false, 0, 139, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Attraction List", 217, Gx_line+50, 384, Gx_line+100, 0, 0, 0, 0) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "c83a6c4a-3ef2-46d5-bd89-48019a06c121", "", context.GetTheme( )), 25, Gx_line+33, 158, Gx_line+116) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+135);
            /* Using cursor P000S2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRK0S2 = false;
               A9CountryId = P000S2_A9CountryId[0];
               n9CountryId = P000S2_n9CountryId[0];
               A12CategoryId = P000S2_A12CategoryId[0];
               n12CategoryId = P000S2_n12CategoryId[0];
               A40000AttractionFoto_GXI = P000S2_A40000AttractionFoto_GXI[0];
               A10CountryName = P000S2_A10CountryName[0];
               A8AttractionName = P000S2_A8AttractionName[0];
               A7AttractionId = P000S2_A7AttractionId[0];
               A13CategoryName = P000S2_A13CategoryName[0];
               A14AttractionFoto = P000S2_A14AttractionFoto[0];
               A10CountryName = P000S2_A10CountryName[0];
               A13CategoryName = P000S2_A13CategoryName[0];
               H0S0( false, 100) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Category:", 42, Gx_line+17, 90, Gx_line+31, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A13CategoryName, "")), 117, Gx_line+17, 378, Gx_line+32, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+100);
               H0S0( false, 44) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("ID", 125, Gx_line+17, 137, Gx_line+31, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("NAME", 167, Gx_line+17, 200, Gx_line+31, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("COUNTRY", 425, Gx_line+17, 481, Gx_line+31, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("FOTO", 517, Gx_line+17, 548, Gx_line+31, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(92, Gx_line+33, 550, Gx_line+33, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+44);
               while ( (pr_default.getStatus(0) != 101) && ( P000S2_A12CategoryId[0] == A12CategoryId ) )
               {
                  BRK0S2 = false;
                  A9CountryId = P000S2_A9CountryId[0];
                  n9CountryId = P000S2_n9CountryId[0];
                  A40000AttractionFoto_GXI = P000S2_A40000AttractionFoto_GXI[0];
                  A10CountryName = P000S2_A10CountryName[0];
                  A8AttractionName = P000S2_A8AttractionName[0];
                  A7AttractionId = P000S2_A7AttractionId[0];
                  A14AttractionFoto = P000S2_A14AttractionFoto[0];
                  A10CountryName = P000S2_A10CountryName[0];
                  H0S0( false, 100) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A7AttractionId), "ZZZ9")), 117, Gx_line+0, 143, Gx_line+15, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A8AttractionName, "")), 167, Gx_line+0, 428, Gx_line+15, 0+256, 0, 0, 0) ;
                  sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A14AttractionFoto)) ? A40000AttractionFoto_GXI : A14AttractionFoto);
                  getPrinter().GxDrawBitMap(sImgUrl, 517, Gx_line+0, 617, Gx_line+33) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A10CountryName, "")), 425, Gx_line+0, 495, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+100);
                  BRK0S2 = true;
                  pr_default.readNext(0);
               }
               if ( ! BRK0S2 )
               {
                  BRK0S2 = true;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0S0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void H0S0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         if (IsMain)	waitPrinterEnd();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         P000S2_A9CountryId = new short[1] ;
         P000S2_n9CountryId = new bool[] {false} ;
         P000S2_A12CategoryId = new short[1] ;
         P000S2_n12CategoryId = new bool[] {false} ;
         P000S2_A40000AttractionFoto_GXI = new string[] {""} ;
         P000S2_A10CountryName = new string[] {""} ;
         P000S2_A8AttractionName = new string[] {""} ;
         P000S2_A7AttractionId = new short[1] ;
         P000S2_A13CategoryName = new string[] {""} ;
         P000S2_A14AttractionFoto = new string[] {""} ;
         A40000AttractionFoto_GXI = "";
         A10CountryName = "";
         A8AttractionName = "";
         A13CategoryName = "";
         A14AttractionFoto = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aattractionlistcategorynovacios__default(),
            new Object[][] {
                new Object[] {
               P000S2_A9CountryId, P000S2_n9CountryId, P000S2_A12CategoryId, P000S2_n12CategoryId, P000S2_A40000AttractionFoto_GXI, P000S2_A10CountryName, P000S2_A8AttractionName, P000S2_A7AttractionId, P000S2_A13CategoryName, P000S2_A14AttractionFoto
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short A9CountryId ;
      private short A12CategoryId ;
      private short A7AttractionId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string A10CountryName ;
      private string A8AttractionName ;
      private string A13CategoryName ;
      private string sImgUrl ;
      private bool entryPointCalled ;
      private bool BRK0S2 ;
      private bool n9CountryId ;
      private bool n12CategoryId ;
      private string A40000AttractionFoto_GXI ;
      private string A14AttractionFoto ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000S2_A9CountryId ;
      private bool[] P000S2_n9CountryId ;
      private short[] P000S2_A12CategoryId ;
      private bool[] P000S2_n12CategoryId ;
      private string[] P000S2_A40000AttractionFoto_GXI ;
      private string[] P000S2_A10CountryName ;
      private string[] P000S2_A8AttractionName ;
      private short[] P000S2_A7AttractionId ;
      private string[] P000S2_A13CategoryName ;
      private string[] P000S2_A14AttractionFoto ;
   }

   public class aattractionlistcategorynovacios__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000S2;
          prmP000S2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P000S2", "SELECT T1.[CountryId], T1.[CategoryId], T1.[AttractionFoto_GXI], T2.[CountryName], T1.[AttractionName], T1.[AttractionId], T3.[CategoryName], T1.[AttractionFoto] FROM (([Attraction] T1 LEFT JOIN [Country] T2 ON T2.[CountryId] = T1.[CountryId]) LEFT JOIN [Category] T3 ON T3.[CategoryId] = T1.[CategoryId]) ORDER BY T1.[CategoryId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000S2,100, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[5])[0] = rslt.getString(4, 50);
                ((string[]) buf[6])[0] = rslt.getString(5, 50);
                ((short[]) buf[7])[0] = rslt.getShort(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 50);
                ((string[]) buf[9])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(3));
                return;
       }
    }

 }

}
