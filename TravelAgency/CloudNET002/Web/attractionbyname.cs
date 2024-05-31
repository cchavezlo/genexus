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
   public class attractionbyname : GXProcedure
   {
      public attractionbyname( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public attractionbyname( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_AttractionNameForm ,
                           string aP1_AttractionNameTo )
      {
         this.AV2AttractionNameForm = aP0_AttractionNameForm;
         this.AV3AttractionNameTo = aP1_AttractionNameTo;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( string aP0_AttractionNameForm ,
                                 string aP1_AttractionNameTo )
      {
         this.AV2AttractionNameForm = aP0_AttractionNameForm;
         this.AV3AttractionNameTo = aP1_AttractionNameTo;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(string)AV2AttractionNameForm,(string)AV3AttractionNameTo} ;
         ClassLoader.Execute("aattractionbyname","GeneXus.Programs","aattractionbyname", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 2 ) )
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

      private string AV2AttractionNameForm ;
      private string AV3AttractionNameTo ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
   }

}
