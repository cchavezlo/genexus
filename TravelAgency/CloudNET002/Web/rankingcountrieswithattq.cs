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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class rankingcountrieswithattq : GXProcedure
   {
      public rankingcountrieswithattq( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TravelAgency", true);
      }

      public rankingcountrieswithattq( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<SdtSDTCountries_SDTCountriesItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTCountries_SDTCountriesItem>( context, "SDTCountriesItem", "TravelAgency") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtSDTCountries_SDTCountriesItem> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDTCountries_SDTCountriesItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtSDTCountries_SDTCountriesItem>( context, "SDTCountriesItem", "TravelAgency") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00023 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A9CountryId = P00023_A9CountryId[0];
            n9CountryId = P00023_n9CountryId[0];
            A10CountryName = P00023_A10CountryName[0];
            A40000GXC1 = P00023_A40000GXC1[0];
            n40000GXC1 = P00023_n40000GXC1[0];
            A40000GXC1 = P00023_A40000GXC1[0];
            n40000GXC1 = P00023_n40000GXC1[0];
            Gxm1sdtcountries = new SdtSDTCountries_SDTCountriesItem(context);
            Gxm2rootcol.Add(Gxm1sdtcountries, 0);
            Gxm1sdtcountries.gxTpr_Id = A9CountryId;
            Gxm1sdtcountries.gxTpr_Name = A10CountryName;
            Gxm1sdtcountries.gxTpr_Attractionquantity = (short)(A40000GXC1);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P00023_A9CountryId = new short[1] ;
         P00023_n9CountryId = new bool[] {false} ;
         P00023_A10CountryName = new string[] {""} ;
         P00023_A40000GXC1 = new int[1] ;
         P00023_n40000GXC1 = new bool[] {false} ;
         A10CountryName = "";
         Gxm1sdtcountries = new SdtSDTCountries_SDTCountriesItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rankingcountrieswithattq__default(),
            new Object[][] {
                new Object[] {
               P00023_A9CountryId, P00023_A10CountryName, P00023_A40000GXC1, P00023_n40000GXC1
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A9CountryId ;
      private int A40000GXC1 ;
      private string A10CountryName ;
      private bool n9CountryId ;
      private bool n40000GXC1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDTCountries_SDTCountriesItem> Gxm2rootcol ;
      private IDataStoreProvider pr_default ;
      private short[] P00023_A9CountryId ;
      private bool[] P00023_n9CountryId ;
      private string[] P00023_A10CountryName ;
      private int[] P00023_A40000GXC1 ;
      private bool[] P00023_n40000GXC1 ;
      private SdtSDTCountries_SDTCountriesItem Gxm1sdtcountries ;
      private GXBaseCollection<SdtSDTCountries_SDTCountriesItem> aP0_Gxm2rootcol ;
   }

   public class rankingcountrieswithattq__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00023;
          prmP00023 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00023", "SELECT T1.[CountryId], T1.[CountryName], COALESCE( T2.[GXC1], 0) AS GXC1 FROM ([Country] T1 LEFT JOIN (SELECT COUNT(*) AS GXC1, [CountryId] FROM [Attraction] GROUP BY [CountryId] ) T2 ON T2.[CountryId] = T1.[CountryId]) ORDER BY T1.[CountryId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00023,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}
