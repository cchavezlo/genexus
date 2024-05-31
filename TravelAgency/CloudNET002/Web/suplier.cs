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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class suplier : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetNextPar( );
         gxfirstwebparm_bkp = gxfirstwebparm;
         gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            dyncall( GetNextPar( )) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A7AttractionId = (short)(Math.Round(NumberUtil.Val( GetPar( "AttractionId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A7AttractionId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
         {
            setAjaxEventMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridsuplier_attraction") == 0 )
         {
            gxnrGridsuplier_attraction_newrow_invoke( ) ;
            return  ;
         }
         else
         {
            if ( ! IsValidAjaxCall( false) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = gxfirstwebparm_bkp;
         }
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_web_controls( ) ;
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_9-182098", 0) ;
            }
         }
         Form.Meta.addItem("description", "Suplier", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSuplierId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("TravelAgency", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridsuplier_attraction_newrow_invoke( )
      {
         nRC_GXsfl_53 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_53"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_53_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_53_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_53_idx = GetPar( "sGXsfl_53_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridsuplier_attraction_newrow( ) ;
         /* End function gxnrGridsuplier_attraction_newrow_invoke */
      }

      public suplier( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TravelAgency", true);
      }

      public suplier( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterunanimosidebar", "GeneXus.Programs.general.ui.masterunanimosidebar", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "title-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Suplier", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Suplier.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "form-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 form__toolbar-cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-first";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Suplier.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Suplier.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Suplier.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Suplier.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 4, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx00d0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"SUPLIERID"+"'), id:'"+"SUPLIERID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Suplier.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell-advanced", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSuplierId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSuplierId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSuplierId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A37SuplierId), 4, 0, ".", "")), StringUtil.LTrim( ((edtSuplierId_Enabled!=0) ? context.localUtil.Format( (decimal)(A37SuplierId), "ZZZ9") : context.localUtil.Format( (decimal)(A37SuplierId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSuplierId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSuplierId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Suplier.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSuplierName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSuplierName_Internalname, "Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSuplierName_Internalname, StringUtil.RTrim( A38SuplierName), StringUtil.RTrim( context.localUtil.Format( A38SuplierName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSuplierName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSuplierName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Suplier.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSuplierAddress_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSuplierAddress_Internalname, "Address", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtSuplierAddress_Internalname, A39SuplierAddress, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A39SuplierAddress), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtSuplierAddress_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Suplier.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divAttractiontable_Internalname, 1, 0, "px", 0, "px", "form__table-level", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitleattraction_Internalname, "Attraction", "", "", lblTitleattraction_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-04", 0, "", 1, 1, 0, 0, "HLP_Suplier.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         gxdraw_Gridsuplier_attraction( ) ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "end", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Suplier.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Suplier.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Suplier.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridsuplier_attraction( )
      {
         /*  Grid Control  */
         StartGridControl53( ) ;
         nGXsfl_53_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount14 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_14 = 1;
               ScanStart0914( ) ;
               while ( RcdFound14 != 0 )
               {
                  init_level_properties14( ) ;
                  getByPrimaryKey0914( ) ;
                  AddRow0914( ) ;
                  ScanNext0914( ) ;
               }
               ScanEnd0914( ) ;
               nBlankRcdCount14 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0914( ) ;
            standaloneModal0914( ) ;
            sMode14 = Gx_mode;
            while ( nGXsfl_53_idx < nRC_GXsfl_53 )
            {
               bGXsfl_53_Refreshing = true;
               ReadRow0914( ) ;
               edtAttractionId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ATTRACTIONID_"+sGXsfl_53_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtAttractionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttractionId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               edtAttractionName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ATTRACTIONNAME_"+sGXsfl_53_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtAttractionName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttractionName_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               edtAttractionFoto_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ATTRACTIONFOTO_"+sGXsfl_53_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtAttractionFoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttractionFoto_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               edtSuplierAttractionDate_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUPLIERATTRACTIONDATE_"+sGXsfl_53_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtSuplierAttractionDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSuplierAttractionDate_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               imgprompt_7_Link = cgiGet( "PROMPT_7_"+sGXsfl_53_idx+"Link");
               if ( ( nRcdExists_14 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0914( ) ;
               }
               SendRow0914( ) ;
               bGXsfl_53_Refreshing = false;
            }
            Gx_mode = sMode14;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount14 = 5;
            nRcdExists_14 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0914( ) ;
               while ( RcdFound14 != 0 )
               {
                  sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_5314( ) ;
                  init_level_properties14( ) ;
                  standaloneNotModal0914( ) ;
                  getByPrimaryKey0914( ) ;
                  standaloneModal0914( ) ;
                  AddRow0914( ) ;
                  ScanNext0914( ) ;
               }
               ScanEnd0914( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         sMode14 = Gx_mode;
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx+1), 4, 0), 4, "0");
         SubsflControlProps_5314( ) ;
         InitAll0914( ) ;
         init_level_properties14( ) ;
         nRcdExists_14 = 0;
         nIsMod_14 = 0;
         nRcdDeleted_14 = 0;
         nBlankRcdCount14 = (short)(nBlankRcdUsr14+nBlankRcdCount14);
         fRowAdded = 0;
         while ( nBlankRcdCount14 > 0 )
         {
            standaloneNotModal0914( ) ;
            standaloneModal0914( ) ;
            AddRow0914( ) ;
            if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
            {
               fRowAdded = 1;
               GX_FocusControl = edtAttractionId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nBlankRcdCount14 = (short)(nBlankRcdCount14-1);
         }
         Gx_mode = sMode14;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridsuplier_attractionContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridsuplier_attraction", Gridsuplier_attractionContainer, subGridsuplier_attraction_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridsuplier_attractionContainerData", Gridsuplier_attractionContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridsuplier_attractionContainerData"+"V", Gridsuplier_attractionContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridsuplier_attractionContainerData"+"V"+"\" value='"+Gridsuplier_attractionContainer.GridValuesHidden()+"'/>") ;
         }
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z37SuplierId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z37SuplierId"), ".", ","), 18, MidpointRounding.ToEven));
            Z38SuplierName = cgiGet( "Z38SuplierName");
            Z39SuplierAddress = cgiGet( "Z39SuplierAddress");
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            nRC_GXsfl_53 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_53"), ".", ","), 18, MidpointRounding.ToEven));
            A40000AttractionFoto_GXI = cgiGet( "ATTRACTIONFOTO_GXI");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtSuplierId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSuplierId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SUPLIERID");
               AnyError = 1;
               GX_FocusControl = edtSuplierId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A37SuplierId = 0;
               AssignAttri("", false, "A37SuplierId", StringUtil.LTrimStr( (decimal)(A37SuplierId), 4, 0));
            }
            else
            {
               A37SuplierId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSuplierId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A37SuplierId", StringUtil.LTrimStr( (decimal)(A37SuplierId), 4, 0));
            }
            A38SuplierName = cgiGet( edtSuplierName_Internalname);
            AssignAttri("", false, "A38SuplierName", A38SuplierName);
            A39SuplierAddress = cgiGet( edtSuplierAddress_Internalname);
            AssignAttri("", false, "A39SuplierAddress", A39SuplierAddress);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A37SuplierId = (short)(Math.Round(NumberUtil.Val( GetPar( "SuplierId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A37SuplierId", StringUtil.LTrimStr( (decimal)(A37SuplierId), 4, 0));
               getEqualNoModal( ) ;
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               standaloneModal( ) ;
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
            sEvt = cgiGet( "_EventName");
            EvtGridId = cgiGet( "_EventGridId");
            EvtRowId = cgiGet( "_EventRowId");
            if ( StringUtil.Len( sEvt) > 0 )
            {
               sEvtType = StringUtil.Left( sEvt, 1);
               sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
               if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
               {
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
                        }
                     }
                     else
                     {
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0913( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes0913( ) ;
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_0914( )
      {
         nGXsfl_53_idx = 0;
         while ( nGXsfl_53_idx < nRC_GXsfl_53 )
         {
            ReadRow0914( ) ;
            if ( ( nRcdExists_14 != 0 ) || ( nIsMod_14 != 0 ) )
            {
               GetKey0914( ) ;
               if ( ( nRcdExists_14 == 0 ) && ( nRcdDeleted_14 == 0 ) )
               {
                  if ( RcdFound14 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0914( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0914( ) ;
                        CloseExtendedTableCursors0914( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "ATTRACTIONID_" + sGXsfl_53_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtAttractionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound14 != 0 )
                  {
                     if ( nRcdDeleted_14 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0914( ) ;
                        Load0914( ) ;
                        BeforeValidate0914( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0914( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_14 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0914( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0914( ) ;
                              CloseExtendedTableCursors0914( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_14 == 0 )
                     {
                        GXCCtl = "ATTRACTIONID_" + sGXsfl_53_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtAttractionId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtAttractionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A7AttractionId), 4, 0, ".", ""))) ;
            ChangePostValue( edtAttractionName_Internalname, StringUtil.RTrim( A8AttractionName)) ;
            ChangePostValue( edtAttractionFoto_Internalname, A14AttractionFoto) ;
            ChangePostValue( edtSuplierAttractionDate_Internalname, context.localUtil.Format(A43SuplierAttractionDate, "99/99/99")) ;
            ChangePostValue( "ZT_"+"Z7AttractionId_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7AttractionId), 4, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z43SuplierAttractionDate_"+sGXsfl_53_idx, context.localUtil.DToC( Z43SuplierAttractionDate, 0, "/")) ;
            ChangePostValue( "nRcdDeleted_14_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_14), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_14_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_14), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_14_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_14), 4, 0, ".", ""))) ;
            if ( nIsMod_14 != 0 )
            {
               ChangePostValue( "ATTRACTIONID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttractionId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ATTRACTIONNAME_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttractionName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ATTRACTIONFOTO_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttractionFoto_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SUPLIERATTRACTIONDATE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSuplierAttractionDate_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption090( )
      {
      }

      protected void ZM0913( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z38SuplierName = T00096_A38SuplierName[0];
               Z39SuplierAddress = T00096_A39SuplierAddress[0];
            }
            else
            {
               Z38SuplierName = A38SuplierName;
               Z39SuplierAddress = A39SuplierAddress;
            }
         }
         if ( GX_JID == -2 )
         {
            Z37SuplierId = A37SuplierId;
            Z38SuplierName = A38SuplierName;
            Z39SuplierAddress = A39SuplierAddress;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load0913( )
      {
         /* Using cursor T00097 */
         pr_default.execute(5, new Object[] {A37SuplierId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound13 = 1;
            A38SuplierName = T00097_A38SuplierName[0];
            AssignAttri("", false, "A38SuplierName", A38SuplierName);
            A39SuplierAddress = T00097_A39SuplierAddress[0];
            AssignAttri("", false, "A39SuplierAddress", A39SuplierAddress);
            ZM0913( -2) ;
         }
         pr_default.close(5);
         OnLoadActions0913( ) ;
      }

      protected void OnLoadActions0913( )
      {
      }

      protected void CheckExtendedTable0913( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0913( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0913( )
      {
         /* Using cursor T00098 */
         pr_default.execute(6, new Object[] {A37SuplierId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound13 = 1;
         }
         else
         {
            RcdFound13 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00096 */
         pr_default.execute(4, new Object[] {A37SuplierId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM0913( 2) ;
            RcdFound13 = 1;
            A37SuplierId = T00096_A37SuplierId[0];
            AssignAttri("", false, "A37SuplierId", StringUtil.LTrimStr( (decimal)(A37SuplierId), 4, 0));
            A38SuplierName = T00096_A38SuplierName[0];
            AssignAttri("", false, "A38SuplierName", A38SuplierName);
            A39SuplierAddress = T00096_A39SuplierAddress[0];
            AssignAttri("", false, "A39SuplierAddress", A39SuplierAddress);
            Z37SuplierId = A37SuplierId;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0913( ) ;
            if ( AnyError == 1 )
            {
               RcdFound13 = 0;
               InitializeNonKey0913( ) ;
            }
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound13 = 0;
            InitializeNonKey0913( ) ;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey0913( ) ;
         if ( RcdFound13 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound13 = 0;
         /* Using cursor T00099 */
         pr_default.execute(7, new Object[] {A37SuplierId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00099_A37SuplierId[0] < A37SuplierId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00099_A37SuplierId[0] > A37SuplierId ) ) )
            {
               A37SuplierId = T00099_A37SuplierId[0];
               AssignAttri("", false, "A37SuplierId", StringUtil.LTrimStr( (decimal)(A37SuplierId), 4, 0));
               RcdFound13 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void move_previous( )
      {
         RcdFound13 = 0;
         /* Using cursor T000910 */
         pr_default.execute(8, new Object[] {A37SuplierId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000910_A37SuplierId[0] > A37SuplierId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000910_A37SuplierId[0] < A37SuplierId ) ) )
            {
               A37SuplierId = T000910_A37SuplierId[0];
               AssignAttri("", false, "A37SuplierId", StringUtil.LTrimStr( (decimal)(A37SuplierId), 4, 0));
               RcdFound13 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0913( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSuplierId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0913( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound13 == 1 )
            {
               if ( A37SuplierId != Z37SuplierId )
               {
                  A37SuplierId = Z37SuplierId;
                  AssignAttri("", false, "A37SuplierId", StringUtil.LTrimStr( (decimal)(A37SuplierId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SUPLIERID");
                  AnyError = 1;
                  GX_FocusControl = edtSuplierId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSuplierId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0913( ) ;
                  GX_FocusControl = edtSuplierId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A37SuplierId != Z37SuplierId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtSuplierId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0913( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SUPLIERID");
                     AnyError = 1;
                     GX_FocusControl = edtSuplierId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtSuplierId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0913( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      protected void btn_delete( )
      {
         if ( A37SuplierId != Z37SuplierId )
         {
            A37SuplierId = Z37SuplierId;
            AssignAttri("", false, "A37SuplierId", StringUtil.LTrimStr( (decimal)(A37SuplierId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SUPLIERID");
            AnyError = 1;
            GX_FocusControl = edtSuplierId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSuplierId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "SUPLIERID");
            AnyError = 1;
            GX_FocusControl = edtSuplierId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtSuplierName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0913( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSuplierName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0913( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSuplierName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSuplierName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0913( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound13 != 0 )
            {
               ScanNext0913( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSuplierName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0913( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0913( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00095 */
            pr_default.execute(3, new Object[] {A37SuplierId});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Suplier"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) || ( StringUtil.StrCmp(Z38SuplierName, T00095_A38SuplierName[0]) != 0 ) || ( StringUtil.StrCmp(Z39SuplierAddress, T00095_A39SuplierAddress[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z38SuplierName, T00095_A38SuplierName[0]) != 0 )
               {
                  GXUtil.WriteLog("suplier:[seudo value changed for attri]"+"SuplierName");
                  GXUtil.WriteLogRaw("Old: ",Z38SuplierName);
                  GXUtil.WriteLogRaw("Current: ",T00095_A38SuplierName[0]);
               }
               if ( StringUtil.StrCmp(Z39SuplierAddress, T00095_A39SuplierAddress[0]) != 0 )
               {
                  GXUtil.WriteLog("suplier:[seudo value changed for attri]"+"SuplierAddress");
                  GXUtil.WriteLogRaw("Old: ",Z39SuplierAddress);
                  GXUtil.WriteLogRaw("Current: ",T00095_A39SuplierAddress[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Suplier"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0913( )
      {
         BeforeValidate0913( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0913( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0913( 0) ;
            CheckOptimisticConcurrency0913( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0913( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0913( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000911 */
                     pr_default.execute(9, new Object[] {A38SuplierName, A39SuplierAddress});
                     A37SuplierId = T000911_A37SuplierId[0];
                     AssignAttri("", false, "A37SuplierId", StringUtil.LTrimStr( (decimal)(A37SuplierId), 4, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Suplier");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0913( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption090( ) ;
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0913( ) ;
            }
            EndLevel0913( ) ;
         }
         CloseExtendedTableCursors0913( ) ;
      }

      protected void Update0913( )
      {
         BeforeValidate0913( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0913( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0913( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0913( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0913( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000912 */
                     pr_default.execute(10, new Object[] {A38SuplierName, A39SuplierAddress, A37SuplierId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Suplier");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Suplier"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0913( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0913( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
                              ResetCaption090( ) ;
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0913( ) ;
         }
         CloseExtendedTableCursors0913( ) ;
      }

      protected void DeferredUpdate0913( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0913( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0913( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0913( ) ;
            AfterConfirm0913( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0913( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart0914( ) ;
                  while ( RcdFound14 != 0 )
                  {
                     getByPrimaryKey0914( ) ;
                     Delete0914( ) ;
                     ScanNext0914( ) ;
                  }
                  ScanEnd0914( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000913 */
                     pr_default.execute(11, new Object[] {A37SuplierId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Suplier");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           move_next( ) ;
                           if ( RcdFound13 == 0 )
                           {
                              InitAll0913( ) ;
                              Gx_mode = "INS";
                              AssignAttri("", false, "Gx_mode", Gx_mode);
                           }
                           else
                           {
                              getByPrimaryKey( ) ;
                              Gx_mode = "UPD";
                              AssignAttri("", false, "Gx_mode", Gx_mode);
                           }
                           endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                           endTrnMsgCod = "SuccessfullyDeleted";
                           ResetCaption090( ) ;
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
         }
         sMode13 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0913( ) ;
         Gx_mode = sMode13;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0913( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void ProcessNestedLevel0914( )
      {
         nGXsfl_53_idx = 0;
         while ( nGXsfl_53_idx < nRC_GXsfl_53 )
         {
            ReadRow0914( ) ;
            if ( ( nRcdExists_14 != 0 ) || ( nIsMod_14 != 0 ) )
            {
               standaloneNotModal0914( ) ;
               GetKey0914( ) ;
               if ( ( nRcdExists_14 == 0 ) && ( nRcdDeleted_14 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0914( ) ;
               }
               else
               {
                  if ( RcdFound14 != 0 )
                  {
                     if ( ( nRcdDeleted_14 != 0 ) && ( nRcdExists_14 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0914( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_14 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0914( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_14 == 0 )
                     {
                        GXCCtl = "ATTRACTIONID_" + sGXsfl_53_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtAttractionId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtAttractionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A7AttractionId), 4, 0, ".", ""))) ;
            ChangePostValue( edtAttractionName_Internalname, StringUtil.RTrim( A8AttractionName)) ;
            ChangePostValue( edtAttractionFoto_Internalname, A14AttractionFoto) ;
            ChangePostValue( edtSuplierAttractionDate_Internalname, context.localUtil.Format(A43SuplierAttractionDate, "99/99/99")) ;
            ChangePostValue( "ZT_"+"Z7AttractionId_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7AttractionId), 4, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z43SuplierAttractionDate_"+sGXsfl_53_idx, context.localUtil.DToC( Z43SuplierAttractionDate, 0, "/")) ;
            ChangePostValue( "nRcdDeleted_14_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_14), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_14_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_14), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_14_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_14), 4, 0, ".", ""))) ;
            if ( nIsMod_14 != 0 )
            {
               ChangePostValue( "ATTRACTIONID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttractionId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ATTRACTIONNAME_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttractionName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ATTRACTIONFOTO_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttractionFoto_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SUPLIERATTRACTIONDATE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSuplierAttractionDate_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0914( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_14 = 0;
         nIsMod_14 = 0;
         nRcdDeleted_14 = 0;
      }

      protected void ProcessLevel0913( )
      {
         /* Save parent mode. */
         sMode13 = Gx_mode;
         ProcessNestedLevel0914( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode13;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel0913( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0913( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            context.CommitDataStores("suplier",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues090( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            context.RollbackDataStores("suplier",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0913( )
      {
         /* Using cursor T000914 */
         pr_default.execute(12);
         RcdFound13 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound13 = 1;
            A37SuplierId = T000914_A37SuplierId[0];
            AssignAttri("", false, "A37SuplierId", StringUtil.LTrimStr( (decimal)(A37SuplierId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0913( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound13 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound13 = 1;
            A37SuplierId = T000914_A37SuplierId[0];
            AssignAttri("", false, "A37SuplierId", StringUtil.LTrimStr( (decimal)(A37SuplierId), 4, 0));
         }
      }

      protected void ScanEnd0913( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0913( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0913( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0913( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0913( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0913( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0913( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0913( )
      {
         edtSuplierId_Enabled = 0;
         AssignProp("", false, edtSuplierId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSuplierId_Enabled), 5, 0), true);
         edtSuplierName_Enabled = 0;
         AssignProp("", false, edtSuplierName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSuplierName_Enabled), 5, 0), true);
         edtSuplierAddress_Enabled = 0;
         AssignProp("", false, edtSuplierAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSuplierAddress_Enabled), 5, 0), true);
      }

      protected void ZM0914( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z43SuplierAttractionDate = T00093_A43SuplierAttractionDate[0];
            }
            else
            {
               Z43SuplierAttractionDate = A43SuplierAttractionDate;
            }
         }
         if ( GX_JID == -3 )
         {
            Z37SuplierId = A37SuplierId;
            Z43SuplierAttractionDate = A43SuplierAttractionDate;
            Z7AttractionId = A7AttractionId;
            Z8AttractionName = A8AttractionName;
            Z14AttractionFoto = A14AttractionFoto;
            Z40000AttractionFoto_GXI = A40000AttractionFoto_GXI;
         }
      }

      protected void standaloneNotModal0914( )
      {
      }

      protected void standaloneModal0914( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtAttractionId_Enabled = 0;
            AssignProp("", false, edtAttractionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttractionId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         }
         else
         {
            edtAttractionId_Enabled = 1;
            AssignProp("", false, edtAttractionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttractionId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         }
      }

      protected void Load0914( )
      {
         /* Using cursor T000915 */
         pr_default.execute(13, new Object[] {A37SuplierId, A7AttractionId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound14 = 1;
            A8AttractionName = T000915_A8AttractionName[0];
            A40000AttractionFoto_GXI = T000915_A40000AttractionFoto_GXI[0];
            AssignProp("", false, edtAttractionFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A14AttractionFoto)) ? A40000AttractionFoto_GXI : context.convertURL( context.PathToRelativeUrl( A14AttractionFoto))), !bGXsfl_53_Refreshing);
            AssignProp("", false, edtAttractionFoto_Internalname, "SrcSet", context.GetImageSrcSet( A14AttractionFoto), true);
            A43SuplierAttractionDate = T000915_A43SuplierAttractionDate[0];
            A14AttractionFoto = T000915_A14AttractionFoto[0];
            AssignProp("", false, edtAttractionFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A14AttractionFoto)) ? A40000AttractionFoto_GXI : context.convertURL( context.PathToRelativeUrl( A14AttractionFoto))), !bGXsfl_53_Refreshing);
            AssignProp("", false, edtAttractionFoto_Internalname, "SrcSet", context.GetImageSrcSet( A14AttractionFoto), true);
            ZM0914( -3) ;
         }
         pr_default.close(13);
         OnLoadActions0914( ) ;
      }

      protected void OnLoadActions0914( )
      {
      }

      protected void CheckExtendedTable0914( )
      {
         nIsDirty_14 = 0;
         Gx_BScreen = 1;
         standaloneModal0914( ) ;
         /* Using cursor T00094 */
         pr_default.execute(2, new Object[] {A7AttractionId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "ATTRACTIONID_" + sGXsfl_53_idx;
            GX_msglist.addItem("No matching 'Attraction'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtAttractionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A8AttractionName = T00094_A8AttractionName[0];
         A40000AttractionFoto_GXI = T00094_A40000AttractionFoto_GXI[0];
         AssignProp("", false, edtAttractionFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A14AttractionFoto)) ? A40000AttractionFoto_GXI : context.convertURL( context.PathToRelativeUrl( A14AttractionFoto))), !bGXsfl_53_Refreshing);
         AssignProp("", false, edtAttractionFoto_Internalname, "SrcSet", context.GetImageSrcSet( A14AttractionFoto), true);
         A14AttractionFoto = T00094_A14AttractionFoto[0];
         AssignProp("", false, edtAttractionFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A14AttractionFoto)) ? A40000AttractionFoto_GXI : context.convertURL( context.PathToRelativeUrl( A14AttractionFoto))), !bGXsfl_53_Refreshing);
         AssignProp("", false, edtAttractionFoto_Internalname, "SrcSet", context.GetImageSrcSet( A14AttractionFoto), true);
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A43SuplierAttractionDate) || ( DateTimeUtil.ResetTime ( A43SuplierAttractionDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GXCCtl = "SUPLIERATTRACTIONDATE_" + sGXsfl_53_idx;
            GX_msglist.addItem("Field Suplier Attraction Date is out of range", "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtSuplierAttractionDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0914( )
      {
         pr_default.close(2);
      }

      protected void enableDisable0914( )
      {
      }

      protected void gxLoad_4( short A7AttractionId )
      {
         /* Using cursor T000916 */
         pr_default.execute(14, new Object[] {A7AttractionId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GXCCtl = "ATTRACTIONID_" + sGXsfl_53_idx;
            GX_msglist.addItem("No matching 'Attraction'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtAttractionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A8AttractionName = T000916_A8AttractionName[0];
         A40000AttractionFoto_GXI = T000916_A40000AttractionFoto_GXI[0];
         AssignProp("", false, edtAttractionFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A14AttractionFoto)) ? A40000AttractionFoto_GXI : context.convertURL( context.PathToRelativeUrl( A14AttractionFoto))), !bGXsfl_53_Refreshing);
         AssignProp("", false, edtAttractionFoto_Internalname, "SrcSet", context.GetImageSrcSet( A14AttractionFoto), true);
         A14AttractionFoto = T000916_A14AttractionFoto[0];
         AssignProp("", false, edtAttractionFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A14AttractionFoto)) ? A40000AttractionFoto_GXI : context.convertURL( context.PathToRelativeUrl( A14AttractionFoto))), !bGXsfl_53_Refreshing);
         AssignProp("", false, edtAttractionFoto_Internalname, "SrcSet", context.GetImageSrcSet( A14AttractionFoto), true);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A8AttractionName))+"\""+","+"\""+GXUtil.EncodeJSConstant( A14AttractionFoto)+"\""+","+"\""+GXUtil.EncodeJSConstant( A40000AttractionFoto_GXI)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void GetKey0914( )
      {
         /* Using cursor T000917 */
         pr_default.execute(15, new Object[] {A37SuplierId, A7AttractionId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound14 = 1;
         }
         else
         {
            RcdFound14 = 0;
         }
         pr_default.close(15);
      }

      protected void getByPrimaryKey0914( )
      {
         /* Using cursor T00093 */
         pr_default.execute(1, new Object[] {A37SuplierId, A7AttractionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0914( 3) ;
            RcdFound14 = 1;
            InitializeNonKey0914( ) ;
            A43SuplierAttractionDate = T00093_A43SuplierAttractionDate[0];
            A7AttractionId = T00093_A7AttractionId[0];
            Z37SuplierId = A37SuplierId;
            Z7AttractionId = A7AttractionId;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0914( ) ;
            Load0914( ) ;
            Gx_mode = sMode14;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound14 = 0;
            InitializeNonKey0914( ) ;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0914( ) ;
            Gx_mode = sMode14;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0914( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0914( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00092 */
            pr_default.execute(0, new Object[] {A37SuplierId, A7AttractionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SuplierAttraction"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z43SuplierAttractionDate ) != DateTimeUtil.ResetTime ( T00092_A43SuplierAttractionDate[0] ) ) )
            {
               if ( DateTimeUtil.ResetTime ( Z43SuplierAttractionDate ) != DateTimeUtil.ResetTime ( T00092_A43SuplierAttractionDate[0] ) )
               {
                  GXUtil.WriteLog("suplier:[seudo value changed for attri]"+"SuplierAttractionDate");
                  GXUtil.WriteLogRaw("Old: ",Z43SuplierAttractionDate);
                  GXUtil.WriteLogRaw("Current: ",T00092_A43SuplierAttractionDate[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SuplierAttraction"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0914( )
      {
         BeforeValidate0914( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0914( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0914( 0) ;
            CheckOptimisticConcurrency0914( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0914( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0914( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000918 */
                     pr_default.execute(16, new Object[] {A37SuplierId, A43SuplierAttractionDate, A7AttractionId});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("SuplierAttraction");
                     if ( (pr_default.getStatus(16) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0914( ) ;
            }
            EndLevel0914( ) ;
         }
         CloseExtendedTableCursors0914( ) ;
      }

      protected void Update0914( )
      {
         BeforeValidate0914( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0914( ) ;
         }
         if ( ( nIsMod_14 != 0 ) || ( nIsDirty_14 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0914( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0914( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0914( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000919 */
                        pr_default.execute(17, new Object[] {A43SuplierAttractionDate, A37SuplierId, A7AttractionId});
                        pr_default.close(17);
                        pr_default.SmartCacheProvider.SetUpdated("SuplierAttraction");
                        if ( (pr_default.getStatus(17) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SuplierAttraction"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0914( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0914( ) ;
                           }
                        }
                        else
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                           AnyError = 1;
                        }
                     }
                  }
               }
               EndLevel0914( ) ;
            }
         }
         CloseExtendedTableCursors0914( ) ;
      }

      protected void DeferredUpdate0914( )
      {
      }

      protected void Delete0914( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0914( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0914( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0914( ) ;
            AfterConfirm0914( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0914( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000920 */
                  pr_default.execute(18, new Object[] {A37SuplierId, A7AttractionId});
                  pr_default.close(18);
                  pr_default.SmartCacheProvider.SetUpdated("SuplierAttraction");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode14 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0914( ) ;
         Gx_mode = sMode14;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0914( )
      {
         standaloneModal0914( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000921 */
            pr_default.execute(19, new Object[] {A7AttractionId});
            A8AttractionName = T000921_A8AttractionName[0];
            A40000AttractionFoto_GXI = T000921_A40000AttractionFoto_GXI[0];
            AssignProp("", false, edtAttractionFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A14AttractionFoto)) ? A40000AttractionFoto_GXI : context.convertURL( context.PathToRelativeUrl( A14AttractionFoto))), !bGXsfl_53_Refreshing);
            AssignProp("", false, edtAttractionFoto_Internalname, "SrcSet", context.GetImageSrcSet( A14AttractionFoto), true);
            A14AttractionFoto = T000921_A14AttractionFoto[0];
            AssignProp("", false, edtAttractionFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A14AttractionFoto)) ? A40000AttractionFoto_GXI : context.convertURL( context.PathToRelativeUrl( A14AttractionFoto))), !bGXsfl_53_Refreshing);
            AssignProp("", false, edtAttractionFoto_Internalname, "SrcSet", context.GetImageSrcSet( A14AttractionFoto), true);
            pr_default.close(19);
         }
      }

      protected void EndLevel0914( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0914( )
      {
         /* Scan By routine */
         /* Using cursor T000922 */
         pr_default.execute(20, new Object[] {A37SuplierId});
         RcdFound14 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound14 = 1;
            A7AttractionId = T000922_A7AttractionId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0914( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound14 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound14 = 1;
            A7AttractionId = T000922_A7AttractionId[0];
         }
      }

      protected void ScanEnd0914( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm0914( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0914( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0914( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0914( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0914( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0914( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0914( )
      {
         edtAttractionId_Enabled = 0;
         AssignProp("", false, edtAttractionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttractionId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtAttractionName_Enabled = 0;
         AssignProp("", false, edtAttractionName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttractionName_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtAttractionFoto_Enabled = 0;
         AssignProp("", false, edtAttractionFoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttractionFoto_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtSuplierAttractionDate_Enabled = 0;
         AssignProp("", false, edtSuplierAttractionDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSuplierAttractionDate_Enabled), 5, 0), !bGXsfl_53_Refreshing);
      }

      protected void send_integrity_lvl_hashes0914( )
      {
      }

      protected void send_integrity_lvl_hashes0913( )
      {
      }

      protected void SubsflControlProps_5314( )
      {
         edtAttractionId_Internalname = "ATTRACTIONID_"+sGXsfl_53_idx;
         imgprompt_7_Internalname = "PROMPT_7_"+sGXsfl_53_idx;
         edtAttractionName_Internalname = "ATTRACTIONNAME_"+sGXsfl_53_idx;
         edtAttractionFoto_Internalname = "ATTRACTIONFOTO_"+sGXsfl_53_idx;
         edtSuplierAttractionDate_Internalname = "SUPLIERATTRACTIONDATE_"+sGXsfl_53_idx;
      }

      protected void SubsflControlProps_fel_5314( )
      {
         edtAttractionId_Internalname = "ATTRACTIONID_"+sGXsfl_53_fel_idx;
         imgprompt_7_Internalname = "PROMPT_7_"+sGXsfl_53_fel_idx;
         edtAttractionName_Internalname = "ATTRACTIONNAME_"+sGXsfl_53_fel_idx;
         edtAttractionFoto_Internalname = "ATTRACTIONFOTO_"+sGXsfl_53_fel_idx;
         edtSuplierAttractionDate_Internalname = "SUPLIERATTRACTIONDATE_"+sGXsfl_53_fel_idx;
      }

      protected void AddRow0914( )
      {
         nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_5314( ) ;
         SendRow0914( ) ;
      }

      protected void SendRow0914( )
      {
         Gridsuplier_attractionRow = GXWebRow.GetNew(context);
         if ( subGridsuplier_attraction_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridsuplier_attraction_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridsuplier_attraction_Class, "") != 0 )
            {
               subGridsuplier_attraction_Linesclass = subGridsuplier_attraction_Class+"Odd";
            }
         }
         else if ( subGridsuplier_attraction_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridsuplier_attraction_Backstyle = 0;
            subGridsuplier_attraction_Backcolor = subGridsuplier_attraction_Allbackcolor;
            if ( StringUtil.StrCmp(subGridsuplier_attraction_Class, "") != 0 )
            {
               subGridsuplier_attraction_Linesclass = subGridsuplier_attraction_Class+"Uniform";
            }
         }
         else if ( subGridsuplier_attraction_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridsuplier_attraction_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridsuplier_attraction_Class, "") != 0 )
            {
               subGridsuplier_attraction_Linesclass = subGridsuplier_attraction_Class+"Odd";
            }
            subGridsuplier_attraction_Backcolor = (int)(0x0);
         }
         else if ( subGridsuplier_attraction_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridsuplier_attraction_Backstyle = 1;
            if ( ((int)((nGXsfl_53_idx) % (2))) == 0 )
            {
               subGridsuplier_attraction_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridsuplier_attraction_Class, "") != 0 )
               {
                  subGridsuplier_attraction_Linesclass = subGridsuplier_attraction_Class+"Even";
               }
            }
            else
            {
               subGridsuplier_attraction_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridsuplier_attraction_Class, "") != 0 )
               {
                  subGridsuplier_attraction_Linesclass = subGridsuplier_attraction_Class+"Odd";
               }
            }
         }
         imgprompt_7_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"ATTRACTIONID_"+sGXsfl_53_idx+"'), id:'"+"ATTRACTIONID_"+sGXsfl_53_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_14_"+sGXsfl_53_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_14_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_53_idx + "',53)\"";
         ROClassString = "Attribute";
         Gridsuplier_attractionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAttractionId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A7AttractionId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A7AttractionId), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,54);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAttractionId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtAttractionId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)53,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_7_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_7_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         Gridsuplier_attractionRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_7_Internalname,(string)sImgUrl,(string)imgprompt_7_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_7_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridsuplier_attractionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAttractionName_Internalname,StringUtil.RTrim( A8AttractionName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAttractionName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtAttractionName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)53,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Static Bitmap Variable */
         ClassString = "ImageAttribute";
         StyleString = "";
         A14AttractionFoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A14AttractionFoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000AttractionFoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A14AttractionFoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A14AttractionFoto)) ? A40000AttractionFoto_GXI : context.PathToRelativeUrl( A14AttractionFoto));
         Gridsuplier_attractionRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtAttractionFoto_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(int)edtAttractionFoto_Enabled,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)0,(bool)A14AttractionFoto_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl)});
         AssignProp("", false, edtAttractionFoto_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A14AttractionFoto)) ? A40000AttractionFoto_GXI : context.PathToRelativeUrl( A14AttractionFoto)), !bGXsfl_53_Refreshing);
         AssignProp("", false, edtAttractionFoto_Internalname, "IsBlob", StringUtil.BoolToStr( A14AttractionFoto_IsBlob), !bGXsfl_53_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_14_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_53_idx + "',53)\"";
         ROClassString = "Attribute";
         Gridsuplier_attractionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSuplierAttractionDate_Internalname,context.localUtil.Format(A43SuplierAttractionDate, "99/99/99"),context.localUtil.Format( A43SuplierAttractionDate, "99/99/99"),TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,57);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSuplierAttractionDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtSuplierAttractionDate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)53,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         ajax_sending_grid_row(Gridsuplier_attractionRow);
         send_integrity_lvl_hashes0914( ) ;
         GXCCtl = "Z7AttractionId_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7AttractionId), 4, 0, ".", "")));
         GXCCtl = "Z43SuplierAttractionDate_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.DToC( Z43SuplierAttractionDate, 0, "/"));
         GXCCtl = "nRcdDeleted_14_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_14), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_14_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_14), 4, 0, ".", "")));
         GXCCtl = "nIsMod_14_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_14), 4, 0, ".", "")));
         GXCCtl = "ATTRACTIONFOTO_" + sGXsfl_53_idx;
         GXCCtlgxBlob = GXCCtl + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A14AttractionFoto);
         GxWebStd.gx_hidden_field( context, "ATTRACTIONID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttractionId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ATTRACTIONNAME_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttractionName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ATTRACTIONFOTO_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttractionFoto_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SUPLIERATTRACTIONDATE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSuplierAttractionDate_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_7_"+sGXsfl_53_idx+"Link", StringUtil.RTrim( imgprompt_7_Link));
         ajax_sending_grid_row(null);
         Gridsuplier_attractionContainer.AddRow(Gridsuplier_attractionRow);
      }

      protected void ReadRow0914( )
      {
         nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_5314( ) ;
         edtAttractionId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ATTRACTIONID_"+sGXsfl_53_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtAttractionName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ATTRACTIONNAME_"+sGXsfl_53_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtAttractionFoto_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ATTRACTIONFOTO_"+sGXsfl_53_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtSuplierAttractionDate_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SUPLIERATTRACTIONDATE_"+sGXsfl_53_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         imgprompt_7_Link = cgiGet( "PROMPT_7_"+sGXsfl_53_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtAttractionId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAttractionId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "ATTRACTIONID_" + sGXsfl_53_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtAttractionId_Internalname;
            wbErr = true;
            A7AttractionId = 0;
         }
         else
         {
            A7AttractionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtAttractionId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
         }
         A8AttractionName = cgiGet( edtAttractionName_Internalname);
         A14AttractionFoto = cgiGet( edtAttractionFoto_Internalname);
         if ( context.localUtil.VCDate( cgiGet( edtSuplierAttractionDate_Internalname), 1) == 0 )
         {
            GXCCtl = "SUPLIERATTRACTIONDATE_" + sGXsfl_53_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Suplier Attraction Date"}), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtSuplierAttractionDate_Internalname;
            wbErr = true;
            A43SuplierAttractionDate = DateTime.MinValue;
         }
         else
         {
            A43SuplierAttractionDate = context.localUtil.CToD( cgiGet( edtSuplierAttractionDate_Internalname), 1);
         }
         GXCCtl = "Z7AttractionId_" + sGXsfl_53_idx;
         Z7AttractionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "Z43SuplierAttractionDate_" + sGXsfl_53_idx;
         Z43SuplierAttractionDate = context.localUtil.CToD( cgiGet( GXCCtl), 0);
         GXCCtl = "nRcdDeleted_14_" + sGXsfl_53_idx;
         nRcdDeleted_14 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_14_" + sGXsfl_53_idx;
         nRcdExists_14 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_14_" + sGXsfl_53_idx;
         nIsMod_14 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         getMultimediaValue(edtAttractionFoto_Internalname, ref  A14AttractionFoto, ref  A40000AttractionFoto_GXI);
      }

      protected void assign_properties_default( )
      {
         defedtAttractionId_Enabled = edtAttractionId_Enabled;
      }

      protected void ConfirmValues090( )
      {
         nGXsfl_53_idx = 0;
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_5314( ) ;
         while ( nGXsfl_53_idx < nRC_GXsfl_53 )
         {
            nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
            sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
            SubsflControlProps_5314( ) ;
            ChangePostValue( "Z7AttractionId_"+sGXsfl_53_idx, cgiGet( "ZT_"+"Z7AttractionId_"+sGXsfl_53_idx)) ;
            DeletePostValue( "ZT_"+"Z7AttractionId_"+sGXsfl_53_idx) ;
            ChangePostValue( "Z43SuplierAttractionDate_"+sGXsfl_53_idx, cgiGet( "ZT_"+"Z43SuplierAttractionDate_"+sGXsfl_53_idx)) ;
            DeletePostValue( "ZT_"+"Z43SuplierAttractionDate_"+sGXsfl_53_idx) ;
         }
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         MasterPageObj.master_styles();
         CloseStyles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1438560), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1438560), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1438560), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1438560), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1438560), false, true);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 1438560), false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("suplier.aspx") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z37SuplierId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z37SuplierId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z38SuplierName", StringUtil.RTrim( Z38SuplierName));
         GxWebStd.gx_hidden_field( context, "Z39SuplierAddress", Z39SuplierAddress);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_53", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_53_idx), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ATTRACTIONFOTO_GXI", A40000AttractionFoto_GXI);
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("suplier.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Suplier" ;
      }

      public override string GetPgmdesc( )
      {
         return "Suplier" ;
      }

      protected void InitializeNonKey0913( )
      {
         A38SuplierName = "";
         AssignAttri("", false, "A38SuplierName", A38SuplierName);
         A39SuplierAddress = "";
         AssignAttri("", false, "A39SuplierAddress", A39SuplierAddress);
         Z38SuplierName = "";
         Z39SuplierAddress = "";
      }

      protected void InitAll0913( )
      {
         A37SuplierId = 0;
         AssignAttri("", false, "A37SuplierId", StringUtil.LTrimStr( (decimal)(A37SuplierId), 4, 0));
         InitializeNonKey0913( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0914( )
      {
         A8AttractionName = "";
         A14AttractionFoto = "";
         AssignProp("", false, edtAttractionFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A14AttractionFoto)) ? A40000AttractionFoto_GXI : context.convertURL( context.PathToRelativeUrl( A14AttractionFoto))), !bGXsfl_53_Refreshing);
         AssignProp("", false, edtAttractionFoto_Internalname, "SrcSet", context.GetImageSrcSet( A14AttractionFoto), true);
         A40000AttractionFoto_GXI = "";
         AssignProp("", false, edtAttractionFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A14AttractionFoto)) ? A40000AttractionFoto_GXI : context.convertURL( context.PathToRelativeUrl( A14AttractionFoto))), !bGXsfl_53_Refreshing);
         AssignProp("", false, edtAttractionFoto_Internalname, "SrcSet", context.GetImageSrcSet( A14AttractionFoto), true);
         A43SuplierAttractionDate = DateTime.MinValue;
         Z43SuplierAttractionDate = DateTime.MinValue;
      }

      protected void InitAll0914( )
      {
         A7AttractionId = 0;
         InitializeNonKey0914( ) ;
      }

      protected void StandaloneModalInsert0914( )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202453015415210", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("suplier.js", "?202453015415211", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties14( )
      {
         edtAttractionId_Enabled = defedtAttractionId_Enabled;
         AssignProp("", false, edtAttractionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttractionId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
      }

      protected void StartGridControl53( )
      {
         Gridsuplier_attractionContainer.AddObjectProperty("GridName", "Gridsuplier_attraction");
         Gridsuplier_attractionContainer.AddObjectProperty("Header", subGridsuplier_attraction_Header);
         Gridsuplier_attractionContainer.AddObjectProperty("Class", "Grid");
         Gridsuplier_attractionContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridsuplier_attractionContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridsuplier_attractionContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsuplier_attraction_Backcolorstyle), 1, 0, ".", "")));
         Gridsuplier_attractionContainer.AddObjectProperty("CmpContext", "");
         Gridsuplier_attractionContainer.AddObjectProperty("InMasterPage", "false");
         Gridsuplier_attractionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridsuplier_attractionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A7AttractionId), 4, 0, ".", ""))));
         Gridsuplier_attractionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttractionId_Enabled), 5, 0, ".", "")));
         Gridsuplier_attractionContainer.AddColumnProperties(Gridsuplier_attractionColumn);
         Gridsuplier_attractionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridsuplier_attractionContainer.AddColumnProperties(Gridsuplier_attractionColumn);
         Gridsuplier_attractionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridsuplier_attractionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A8AttractionName)));
         Gridsuplier_attractionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttractionName_Enabled), 5, 0, ".", "")));
         Gridsuplier_attractionContainer.AddColumnProperties(Gridsuplier_attractionColumn);
         Gridsuplier_attractionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridsuplier_attractionColumn.AddObjectProperty("Value", context.convertURL( A14AttractionFoto));
         Gridsuplier_attractionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttractionFoto_Enabled), 5, 0, ".", "")));
         Gridsuplier_attractionContainer.AddColumnProperties(Gridsuplier_attractionColumn);
         Gridsuplier_attractionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridsuplier_attractionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A43SuplierAttractionDate, "99/99/99")));
         Gridsuplier_attractionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSuplierAttractionDate_Enabled), 5, 0, ".", "")));
         Gridsuplier_attractionContainer.AddColumnProperties(Gridsuplier_attractionColumn);
         Gridsuplier_attractionContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsuplier_attraction_Selectedindex), 4, 0, ".", "")));
         Gridsuplier_attractionContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsuplier_attraction_Allowselection), 1, 0, ".", "")));
         Gridsuplier_attractionContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsuplier_attraction_Selectioncolor), 9, 0, ".", "")));
         Gridsuplier_attractionContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsuplier_attraction_Allowhovering), 1, 0, ".", "")));
         Gridsuplier_attractionContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsuplier_attraction_Hoveringcolor), 9, 0, ".", "")));
         Gridsuplier_attractionContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsuplier_attraction_Allowcollapsing), 1, 0, ".", "")));
         Gridsuplier_attractionContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsuplier_attraction_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtSuplierId_Internalname = "SUPLIERID";
         edtSuplierName_Internalname = "SUPLIERNAME";
         edtSuplierAddress_Internalname = "SUPLIERADDRESS";
         lblTitleattraction_Internalname = "TITLEATTRACTION";
         edtAttractionId_Internalname = "ATTRACTIONID";
         edtAttractionName_Internalname = "ATTRACTIONNAME";
         edtAttractionFoto_Internalname = "ATTRACTIONFOTO";
         edtSuplierAttractionDate_Internalname = "SUPLIERATTRACTIONDATE";
         divAttractiontable_Internalname = "ATTRACTIONTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_7_Internalname = "PROMPT_7";
         subGridsuplier_attraction_Internalname = "GRIDSUPLIER_ATTRACTION";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("TravelAgency", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridsuplier_attraction_Allowcollapsing = 0;
         subGridsuplier_attraction_Allowselection = 0;
         subGridsuplier_attraction_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Suplier";
         edtSuplierAttractionDate_Jsonclick = "";
         edtAttractionName_Jsonclick = "";
         imgprompt_7_Visible = 1;
         imgprompt_7_Link = "";
         imgprompt_7_Visible = 1;
         edtAttractionId_Jsonclick = "";
         subGridsuplier_attraction_Class = "Grid";
         subGridsuplier_attraction_Backcolorstyle = 0;
         edtSuplierAttractionDate_Enabled = 1;
         edtAttractionFoto_Enabled = 0;
         edtAttractionName_Enabled = 0;
         edtAttractionId_Enabled = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtSuplierAddress_Enabled = 1;
         edtSuplierName_Jsonclick = "";
         edtSuplierName_Enabled = 1;
         edtSuplierId_Jsonclick = "";
         edtSuplierId_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridsuplier_attraction_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_5314( ) ;
         while ( nGXsfl_53_idx <= nRC_GXsfl_53 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0914( ) ;
            standaloneModal0914( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0914( ) ;
            nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
            sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
            SubsflControlProps_5314( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridsuplier_attractionContainer)) ;
         /* End function gxnrGridsuplier_attraction_newrow */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtSuplierName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void Valid_Suplierid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A38SuplierName", StringUtil.RTrim( A38SuplierName));
         AssignAttri("", false, "A39SuplierAddress", A39SuplierAddress);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z37SuplierId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z37SuplierId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z38SuplierName", StringUtil.RTrim( Z38SuplierName));
         GxWebStd.gx_hidden_field( context, "Z39SuplierAddress", Z39SuplierAddress);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Attractionid( )
      {
         /* Using cursor T000921 */
         pr_default.execute(19, new Object[] {A7AttractionId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No matching 'Attraction'.", "ForeignKeyNotFound", 1, "ATTRACTIONID");
            AnyError = 1;
            GX_FocusControl = edtAttractionId_Internalname;
         }
         A8AttractionName = T000921_A8AttractionName[0];
         A40000AttractionFoto_GXI = T000921_A40000AttractionFoto_GXI[0];
         A14AttractionFoto = T000921_A14AttractionFoto[0];
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A8AttractionName", StringUtil.RTrim( A8AttractionName));
         AssignAttri("", false, "A14AttractionFoto", context.PathToRelativeUrl( A14AttractionFoto));
         GXCCtl = "ATTRACTIONFOTO_" + sGXsfl_53_idx;
         AssignAttri("", false, "GXCCtl", GXCCtl);
         GXCCtlgxBlob = GXCCtl + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A14AttractionFoto));
         AssignAttri("", false, "A40000AttractionFoto_GXI", A40000AttractionFoto_GXI);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("VALID_SUPLIERID","""{"handler":"Valid_Suplierid","iparms":[{"av":"A37SuplierId","fld":"SUPLIERID","pic":"ZZZ9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"}]""");
         setEventMetadata("VALID_SUPLIERID",""","oparms":[{"av":"A38SuplierName","fld":"SUPLIERNAME"},{"av":"A39SuplierAddress","fld":"SUPLIERADDRESS"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z37SuplierId"},{"av":"Z38SuplierName"},{"av":"Z39SuplierAddress"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_ATTRACTIONID","""{"handler":"Valid_Attractionid","iparms":[{"av":"A7AttractionId","fld":"ATTRACTIONID","pic":"ZZZ9"},{"av":"A8AttractionName","fld":"ATTRACTIONNAME"},{"av":"A14AttractionFoto","fld":"ATTRACTIONFOTO"},{"av":"A40000AttractionFoto_GXI","fld":"ATTRACTIONFOTO_GXI"}]""");
         setEventMetadata("VALID_ATTRACTIONID",""","oparms":[{"av":"A8AttractionName","fld":"ATTRACTIONNAME"},{"av":"A14AttractionFoto","fld":"ATTRACTIONFOTO"},{"av":"A40000AttractionFoto_GXI","fld":"ATTRACTIONFOTO_GXI"}]}""");
         setEventMetadata("VALID_SUPLIERATTRACTIONDATE","""{"handler":"Valid_Suplierattractiondate","iparms":[]}""");
         return  ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected override void CloseCursors( )
      {
         pr_default.close(1);
         pr_default.close(19);
         pr_default.close(4);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z38SuplierName = "";
         Z39SuplierAddress = "";
         Z43SuplierAttractionDate = DateTime.MinValue;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         Gx_mode = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A38SuplierName = "";
         A39SuplierAddress = "";
         lblTitleattraction_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridsuplier_attractionContainer = new GXWebGrid( context);
         sMode14 = "";
         sStyleString = "";
         A40000AttractionFoto_GXI = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A8AttractionName = "";
         A14AttractionFoto = "";
         A43SuplierAttractionDate = DateTime.MinValue;
         T00097_A37SuplierId = new short[1] ;
         T00097_A38SuplierName = new string[] {""} ;
         T00097_A39SuplierAddress = new string[] {""} ;
         T00098_A37SuplierId = new short[1] ;
         T00096_A37SuplierId = new short[1] ;
         T00096_A38SuplierName = new string[] {""} ;
         T00096_A39SuplierAddress = new string[] {""} ;
         sMode13 = "";
         T00099_A37SuplierId = new short[1] ;
         T000910_A37SuplierId = new short[1] ;
         T00095_A37SuplierId = new short[1] ;
         T00095_A38SuplierName = new string[] {""} ;
         T00095_A39SuplierAddress = new string[] {""} ;
         T000911_A37SuplierId = new short[1] ;
         T000914_A37SuplierId = new short[1] ;
         Z8AttractionName = "";
         Z14AttractionFoto = "";
         Z40000AttractionFoto_GXI = "";
         T000915_A37SuplierId = new short[1] ;
         T000915_A8AttractionName = new string[] {""} ;
         T000915_A40000AttractionFoto_GXI = new string[] {""} ;
         T000915_A43SuplierAttractionDate = new DateTime[] {DateTime.MinValue} ;
         T000915_A7AttractionId = new short[1] ;
         T000915_A14AttractionFoto = new string[] {""} ;
         T00094_A8AttractionName = new string[] {""} ;
         T00094_A40000AttractionFoto_GXI = new string[] {""} ;
         T00094_A14AttractionFoto = new string[] {""} ;
         T000916_A8AttractionName = new string[] {""} ;
         T000916_A40000AttractionFoto_GXI = new string[] {""} ;
         T000916_A14AttractionFoto = new string[] {""} ;
         T000917_A37SuplierId = new short[1] ;
         T000917_A7AttractionId = new short[1] ;
         T00093_A37SuplierId = new short[1] ;
         T00093_A43SuplierAttractionDate = new DateTime[] {DateTime.MinValue} ;
         T00093_A7AttractionId = new short[1] ;
         T00092_A37SuplierId = new short[1] ;
         T00092_A43SuplierAttractionDate = new DateTime[] {DateTime.MinValue} ;
         T00092_A7AttractionId = new short[1] ;
         T000921_A8AttractionName = new string[] {""} ;
         T000921_A40000AttractionFoto_GXI = new string[] {""} ;
         T000921_A14AttractionFoto = new string[] {""} ;
         T000922_A37SuplierId = new short[1] ;
         T000922_A7AttractionId = new short[1] ;
         Gridsuplier_attractionRow = new GXWebRow();
         subGridsuplier_attraction_Linesclass = "";
         ROClassString = "";
         imgprompt_7_gximage = "";
         sImgUrl = "";
         GXCCtlgxBlob = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gridsuplier_attractionColumn = new GXWebColumn();
         ZZ38SuplierName = "";
         ZZ39SuplierAddress = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.suplier__default(),
            new Object[][] {
                new Object[] {
               T00092_A37SuplierId, T00092_A43SuplierAttractionDate, T00092_A7AttractionId
               }
               , new Object[] {
               T00093_A37SuplierId, T00093_A43SuplierAttractionDate, T00093_A7AttractionId
               }
               , new Object[] {
               T00094_A8AttractionName, T00094_A40000AttractionFoto_GXI, T00094_A14AttractionFoto
               }
               , new Object[] {
               T00095_A37SuplierId, T00095_A38SuplierName, T00095_A39SuplierAddress
               }
               , new Object[] {
               T00096_A37SuplierId, T00096_A38SuplierName, T00096_A39SuplierAddress
               }
               , new Object[] {
               T00097_A37SuplierId, T00097_A38SuplierName, T00097_A39SuplierAddress
               }
               , new Object[] {
               T00098_A37SuplierId
               }
               , new Object[] {
               T00099_A37SuplierId
               }
               , new Object[] {
               T000910_A37SuplierId
               }
               , new Object[] {
               T000911_A37SuplierId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000914_A37SuplierId
               }
               , new Object[] {
               T000915_A37SuplierId, T000915_A8AttractionName, T000915_A40000AttractionFoto_GXI, T000915_A43SuplierAttractionDate, T000915_A7AttractionId, T000915_A14AttractionFoto
               }
               , new Object[] {
               T000916_A8AttractionName, T000916_A40000AttractionFoto_GXI, T000916_A14AttractionFoto
               }
               , new Object[] {
               T000917_A37SuplierId, T000917_A7AttractionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000921_A8AttractionName, T000921_A40000AttractionFoto_GXI, T000921_A14AttractionFoto
               }
               , new Object[] {
               T000922_A37SuplierId, T000922_A7AttractionId
               }
            }
         );
      }

      private short nIsMod_14 ;
      private short Z37SuplierId ;
      private short Z7AttractionId ;
      private short nRcdDeleted_14 ;
      private short nRcdExists_14 ;
      private short GxWebError ;
      private short A7AttractionId ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A37SuplierId ;
      private short nBlankRcdCount14 ;
      private short RcdFound14 ;
      private short nBlankRcdUsr14 ;
      private short RcdFound13 ;
      private short Gx_BScreen ;
      private short nIsDirty_14 ;
      private short subGridsuplier_attraction_Backcolorstyle ;
      private short subGridsuplier_attraction_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridsuplier_attraction_Allowselection ;
      private short subGridsuplier_attraction_Allowhovering ;
      private short subGridsuplier_attraction_Allowcollapsing ;
      private short subGridsuplier_attraction_Collapsed ;
      private short ZZ37SuplierId ;
      private int nRC_GXsfl_53 ;
      private int nGXsfl_53_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtSuplierId_Enabled ;
      private int edtSuplierName_Enabled ;
      private int edtSuplierAddress_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtAttractionId_Enabled ;
      private int edtAttractionName_Enabled ;
      private int edtAttractionFoto_Enabled ;
      private int edtSuplierAttractionDate_Enabled ;
      private int fRowAdded ;
      private int subGridsuplier_attraction_Backcolor ;
      private int subGridsuplier_attraction_Allbackcolor ;
      private int imgprompt_7_Visible ;
      private int defedtAttractionId_Enabled ;
      private int idxLst ;
      private int subGridsuplier_attraction_Selectedindex ;
      private int subGridsuplier_attraction_Selectioncolor ;
      private int subGridsuplier_attraction_Hoveringcolor ;
      private long GRIDSUPLIER_ATTRACTION_nFirstRecordOnPage ;
      private string sPrefix ;
      private string sGXsfl_53_idx="0001" ;
      private string Z38SuplierName ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtSuplierId_Internalname ;
      private string Gx_mode ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtSuplierId_Jsonclick ;
      private string edtSuplierName_Internalname ;
      private string A38SuplierName ;
      private string edtSuplierName_Jsonclick ;
      private string edtSuplierAddress_Internalname ;
      private string divAttractiontable_Internalname ;
      private string lblTitleattraction_Internalname ;
      private string lblTitleattraction_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sMode14 ;
      private string edtAttractionId_Internalname ;
      private string edtAttractionName_Internalname ;
      private string edtAttractionFoto_Internalname ;
      private string edtSuplierAttractionDate_Internalname ;
      private string imgprompt_7_Link ;
      private string sStyleString ;
      private string subGridsuplier_attraction_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string A8AttractionName ;
      private string sMode13 ;
      private string Z8AttractionName ;
      private string imgprompt_7_Internalname ;
      private string sGXsfl_53_fel_idx="0001" ;
      private string subGridsuplier_attraction_Class ;
      private string subGridsuplier_attraction_Linesclass ;
      private string ROClassString ;
      private string edtAttractionId_Jsonclick ;
      private string imgprompt_7_gximage ;
      private string sImgUrl ;
      private string edtAttractionName_Jsonclick ;
      private string edtSuplierAttractionDate_Jsonclick ;
      private string GXCCtlgxBlob ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridsuplier_attraction_Header ;
      private string ZZ38SuplierName ;
      private DateTime Z43SuplierAttractionDate ;
      private DateTime A43SuplierAttractionDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool bGXsfl_53_Refreshing=false ;
      private bool A14AttractionFoto_IsBlob ;
      private string Z39SuplierAddress ;
      private string A39SuplierAddress ;
      private string A40000AttractionFoto_GXI ;
      private string Z40000AttractionFoto_GXI ;
      private string ZZ39SuplierAddress ;
      private string A14AttractionFoto ;
      private string Z14AttractionFoto ;
      private GXWebGrid Gridsuplier_attractionContainer ;
      private GXWebRow Gridsuplier_attractionRow ;
      private GXWebColumn Gridsuplier_attractionColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T00097_A37SuplierId ;
      private string[] T00097_A38SuplierName ;
      private string[] T00097_A39SuplierAddress ;
      private short[] T00098_A37SuplierId ;
      private short[] T00096_A37SuplierId ;
      private string[] T00096_A38SuplierName ;
      private string[] T00096_A39SuplierAddress ;
      private short[] T00099_A37SuplierId ;
      private short[] T000910_A37SuplierId ;
      private short[] T00095_A37SuplierId ;
      private string[] T00095_A38SuplierName ;
      private string[] T00095_A39SuplierAddress ;
      private short[] T000911_A37SuplierId ;
      private short[] T000914_A37SuplierId ;
      private short[] T000915_A37SuplierId ;
      private string[] T000915_A8AttractionName ;
      private string[] T000915_A40000AttractionFoto_GXI ;
      private DateTime[] T000915_A43SuplierAttractionDate ;
      private short[] T000915_A7AttractionId ;
      private string[] T000915_A14AttractionFoto ;
      private string[] T00094_A8AttractionName ;
      private string[] T00094_A40000AttractionFoto_GXI ;
      private string[] T00094_A14AttractionFoto ;
      private string[] T000916_A8AttractionName ;
      private string[] T000916_A40000AttractionFoto_GXI ;
      private string[] T000916_A14AttractionFoto ;
      private short[] T000917_A37SuplierId ;
      private short[] T000917_A7AttractionId ;
      private short[] T00093_A37SuplierId ;
      private DateTime[] T00093_A43SuplierAttractionDate ;
      private short[] T00093_A7AttractionId ;
      private short[] T00092_A37SuplierId ;
      private DateTime[] T00092_A43SuplierAttractionDate ;
      private short[] T00092_A7AttractionId ;
      private string[] T000921_A8AttractionName ;
      private string[] T000921_A40000AttractionFoto_GXI ;
      private string[] T000921_A14AttractionFoto ;
      private short[] T000922_A37SuplierId ;
      private short[] T000922_A7AttractionId ;
   }

   public class suplier__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new UpdateCursor(def[16])
         ,new UpdateCursor(def[17])
         ,new UpdateCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00092;
          prmT00092 = new Object[] {
          new ParDef("@SuplierId",GXType.Int16,4,0) ,
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT00093;
          prmT00093 = new Object[] {
          new ParDef("@SuplierId",GXType.Int16,4,0) ,
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT00094;
          prmT00094 = new Object[] {
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT00095;
          prmT00095 = new Object[] {
          new ParDef("@SuplierId",GXType.Int16,4,0)
          };
          Object[] prmT00096;
          prmT00096 = new Object[] {
          new ParDef("@SuplierId",GXType.Int16,4,0)
          };
          Object[] prmT00097;
          prmT00097 = new Object[] {
          new ParDef("@SuplierId",GXType.Int16,4,0)
          };
          Object[] prmT00098;
          prmT00098 = new Object[] {
          new ParDef("@SuplierId",GXType.Int16,4,0)
          };
          Object[] prmT00099;
          prmT00099 = new Object[] {
          new ParDef("@SuplierId",GXType.Int16,4,0)
          };
          Object[] prmT000910;
          prmT000910 = new Object[] {
          new ParDef("@SuplierId",GXType.Int16,4,0)
          };
          Object[] prmT000911;
          prmT000911 = new Object[] {
          new ParDef("@SuplierName",GXType.NChar,50,0) ,
          new ParDef("@SuplierAddress",GXType.NVarChar,1024,0)
          };
          Object[] prmT000912;
          prmT000912 = new Object[] {
          new ParDef("@SuplierName",GXType.NChar,50,0) ,
          new ParDef("@SuplierAddress",GXType.NVarChar,1024,0) ,
          new ParDef("@SuplierId",GXType.Int16,4,0)
          };
          Object[] prmT000913;
          prmT000913 = new Object[] {
          new ParDef("@SuplierId",GXType.Int16,4,0)
          };
          Object[] prmT000914;
          prmT000914 = new Object[] {
          };
          Object[] prmT000915;
          prmT000915 = new Object[] {
          new ParDef("@SuplierId",GXType.Int16,4,0) ,
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000916;
          prmT000916 = new Object[] {
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000917;
          prmT000917 = new Object[] {
          new ParDef("@SuplierId",GXType.Int16,4,0) ,
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000918;
          prmT000918 = new Object[] {
          new ParDef("@SuplierId",GXType.Int16,4,0) ,
          new ParDef("@SuplierAttractionDate",GXType.Date,8,0) ,
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000919;
          prmT000919 = new Object[] {
          new ParDef("@SuplierAttractionDate",GXType.Date,8,0) ,
          new ParDef("@SuplierId",GXType.Int16,4,0) ,
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000920;
          prmT000920 = new Object[] {
          new ParDef("@SuplierId",GXType.Int16,4,0) ,
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000921;
          prmT000921 = new Object[] {
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000922;
          prmT000922 = new Object[] {
          new ParDef("@SuplierId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00092", "SELECT [SuplierId], [SuplierAttractionDate], [AttractionId] FROM [SuplierAttraction] WITH (UPDLOCK) WHERE [SuplierId] = @SuplierId AND [AttractionId] = @AttractionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00092,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00093", "SELECT [SuplierId], [SuplierAttractionDate], [AttractionId] FROM [SuplierAttraction] WHERE [SuplierId] = @SuplierId AND [AttractionId] = @AttractionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00093,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00094", "SELECT [AttractionName], [AttractionFoto_GXI], [AttractionFoto] FROM [Attraction] WHERE [AttractionId] = @AttractionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00094,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00095", "SELECT [SuplierId], [SuplierName], [SuplierAddress] FROM [Suplier] WITH (UPDLOCK) WHERE [SuplierId] = @SuplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00095,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00096", "SELECT [SuplierId], [SuplierName], [SuplierAddress] FROM [Suplier] WHERE [SuplierId] = @SuplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00096,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00097", "SELECT TM1.[SuplierId], TM1.[SuplierName], TM1.[SuplierAddress] FROM [Suplier] TM1 WHERE TM1.[SuplierId] = @SuplierId ORDER BY TM1.[SuplierId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00097,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00098", "SELECT [SuplierId] FROM [Suplier] WHERE [SuplierId] = @SuplierId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00098,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00099", "SELECT TOP 1 [SuplierId] FROM [Suplier] WHERE ( [SuplierId] > @SuplierId) ORDER BY [SuplierId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00099,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000910", "SELECT TOP 1 [SuplierId] FROM [Suplier] WHERE ( [SuplierId] < @SuplierId) ORDER BY [SuplierId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000910,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000911", "INSERT INTO [Suplier]([SuplierName], [SuplierAddress]) VALUES(@SuplierName, @SuplierAddress); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000911,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000912", "UPDATE [Suplier] SET [SuplierName]=@SuplierName, [SuplierAddress]=@SuplierAddress  WHERE [SuplierId] = @SuplierId", GxErrorMask.GX_NOMASK,prmT000912)
             ,new CursorDef("T000913", "DELETE FROM [Suplier]  WHERE [SuplierId] = @SuplierId", GxErrorMask.GX_NOMASK,prmT000913)
             ,new CursorDef("T000914", "SELECT [SuplierId] FROM [Suplier] ORDER BY [SuplierId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000914,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000915", "SELECT T1.[SuplierId], T2.[AttractionName], T2.[AttractionFoto_GXI], T1.[SuplierAttractionDate], T1.[AttractionId], T2.[AttractionFoto] FROM ([SuplierAttraction] T1 INNER JOIN [Attraction] T2 ON T2.[AttractionId] = T1.[AttractionId]) WHERE T1.[SuplierId] = @SuplierId and T1.[AttractionId] = @AttractionId ORDER BY T1.[SuplierId], T1.[AttractionId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000915,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000916", "SELECT [AttractionName], [AttractionFoto_GXI], [AttractionFoto] FROM [Attraction] WHERE [AttractionId] = @AttractionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000916,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000917", "SELECT [SuplierId], [AttractionId] FROM [SuplierAttraction] WHERE [SuplierId] = @SuplierId AND [AttractionId] = @AttractionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000917,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000918", "INSERT INTO [SuplierAttraction]([SuplierId], [SuplierAttractionDate], [AttractionId]) VALUES(@SuplierId, @SuplierAttractionDate, @AttractionId)", GxErrorMask.GX_NOMASK,prmT000918)
             ,new CursorDef("T000919", "UPDATE [SuplierAttraction] SET [SuplierAttractionDate]=@SuplierAttractionDate  WHERE [SuplierId] = @SuplierId AND [AttractionId] = @AttractionId", GxErrorMask.GX_NOMASK,prmT000919)
             ,new CursorDef("T000920", "DELETE FROM [SuplierAttraction]  WHERE [SuplierId] = @SuplierId AND [AttractionId] = @AttractionId", GxErrorMask.GX_NOMASK,prmT000920)
             ,new CursorDef("T000921", "SELECT [AttractionName], [AttractionFoto_GXI], [AttractionFoto] FROM [Attraction] WHERE [AttractionId] = @AttractionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000921,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000922", "SELECT [SuplierId], [AttractionId] FROM [SuplierAttraction] WHERE [SuplierId] = @SuplierId ORDER BY [SuplierId], [AttractionId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000922,11, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(2));
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(2));
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 19 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(2));
                return;
             case 20 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
