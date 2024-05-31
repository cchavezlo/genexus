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
   public class attractionbynameandcountry : GXProcedure
   {
      public attractionbynameandcountry( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public attractionbynameandcountry( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_Attractioncountry ,
                           string aP1_AttractionNameForm ,
                           string aP2_AttractionNameTo )
      {
         this.AV2Attractioncountry = aP0_Attractioncountry;
         this.AV3AttractionNameForm = aP1_AttractionNameForm;
         this.AV4AttractionNameTo = aP2_AttractionNameTo;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( short aP0_Attractioncountry ,
                                 string aP1_AttractionNameForm ,
                                 string aP2_AttractionNameTo )
      {
         this.AV2Attractioncountry = aP0_Attractioncountry;
         this.AV3AttractionNameForm = aP1_AttractionNameForm;
         this.AV4AttractionNameTo = aP2_AttractionNameTo;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(short)AV2Attractioncountry,(string)AV3AttractionNameForm,(string)AV4AttractionNameTo} ;
         ClassLoader.Execute("aattractionbynameandcountry","GeneXus.Programs","aattractionbynameandcountry", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 3 ) )
         {
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      public override void initialize( )
      {
         /* GeneXus formulas. */
      }

      private short AV2Attractioncountry ;
      private string AV3AttractionNameForm ;
      private string AV4AttractionNameTo ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
   }

}
