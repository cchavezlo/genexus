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
   public class flyght : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_10") == 0 )
         {
            A20FlyghtId = (short)(Math.Round(NumberUtil.Val( GetPar( "FlyghtId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A20FlyghtId", StringUtil.LTrimStr( (decimal)(A20FlyghtId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_10( A20FlyghtId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A22FlyghtDepartureAirportId = (short)(Math.Round(NumberUtil.Val( GetPar( "FlyghtDepartureAirportId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A22FlyghtDepartureAirportId", StringUtil.LTrimStr( (decimal)(A22FlyghtDepartureAirportId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A22FlyghtDepartureAirportId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
         {
            A25FlyghtArrivalAirportId = (short)(Math.Round(NumberUtil.Val( GetPar( "FlyghtArrivalAirportId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A25FlyghtArrivalAirportId", StringUtil.LTrimStr( (decimal)(A25FlyghtArrivalAirportId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A25FlyghtArrivalAirportId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A30AirlineID = (short)(Math.Round(NumberUtil.Val( GetPar( "AirlineID"), "."), 18, MidpointRounding.ToEven));
            n30AirlineID = false;
            AssignAttri("", false, "A30AirlineID", StringUtil.LTrimStr( (decimal)(A30AirlineID), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A30AirlineID) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridflyght_seat") == 0 )
         {
            gxnrGridflyght_seat_newrow_invoke( ) ;
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
         Form.Meta.addItem("description", "Flyght", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtFlyghtId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("TravelAgency", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridflyght_seat_newrow_invoke( )
      {
         nRC_GXsfl_98 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_98"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_98_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_98_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_98_idx = GetPar( "sGXsfl_98_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridflyght_seat_newrow( ) ;
         /* End function gxnrGridflyght_seat_newrow_invoke */
      }

      public flyght( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TravelAgency", true);
      }

      public flyght( IGxContext context )
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
         cmbFlyghtSeatChar = new GXCombobox();
         cmbFlyghtSeatLocation = new GXCombobox();
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Flyght", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Flyght.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Flyght.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Flyght.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Flyght.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Flyght.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 4, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0080.aspx"+"',["+"{Ctrl:gx.dom.el('"+"FLYGHTID"+"'), id:'"+"FLYGHTID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Flyght.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFlyghtId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlyghtId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFlyghtId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A20FlyghtId), 4, 0, ".", "")), StringUtil.LTrim( ((edtFlyghtId_Enabled!=0) ? context.localUtil.Format( (decimal)(A20FlyghtId), "ZZZ9") : context.localUtil.Format( (decimal)(A20FlyghtId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlyghtId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlyghtId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Flyght.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFlyghtDepartureAirportId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlyghtDepartureAirportId_Internalname, "Departure Airport Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFlyghtDepartureAirportId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A22FlyghtDepartureAirportId), 4, 0, ".", "")), StringUtil.LTrim( ((edtFlyghtDepartureAirportId_Enabled!=0) ? context.localUtil.Format( (decimal)(A22FlyghtDepartureAirportId), "ZZZ9") : context.localUtil.Format( (decimal)(A22FlyghtDepartureAirportId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlyghtDepartureAirportId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlyghtDepartureAirportId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Flyght.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_22_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_22_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_22_Internalname, sImgUrl, imgprompt_22_Link, "", "", context.GetTheme( ), imgprompt_22_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Flyght.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFlyghtDepartureAirportName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlyghtDepartureAirportName_Internalname, "Airport Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtFlyghtDepartureAirportName_Internalname, StringUtil.RTrim( A23FlyghtDepartureAirportName), StringUtil.RTrim( context.localUtil.Format( A23FlyghtDepartureAirportName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlyghtDepartureAirportName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlyghtDepartureAirportName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Flyght.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFlyghtArrivalAirportId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlyghtArrivalAirportId_Internalname, "Arrival Airport Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFlyghtArrivalAirportId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A25FlyghtArrivalAirportId), 4, 0, ".", "")), StringUtil.LTrim( ((edtFlyghtArrivalAirportId_Enabled!=0) ? context.localUtil.Format( (decimal)(A25FlyghtArrivalAirportId), "ZZZ9") : context.localUtil.Format( (decimal)(A25FlyghtArrivalAirportId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlyghtArrivalAirportId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlyghtArrivalAirportId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Flyght.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_25_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_25_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_25_Internalname, sImgUrl, imgprompt_25_Link, "", "", context.GetTheme( ), imgprompt_25_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Flyght.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFlyghtArrivalAirportName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlyghtArrivalAirportName_Internalname, "Airport Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtFlyghtArrivalAirportName_Internalname, StringUtil.RTrim( A26FlyghtArrivalAirportName), StringUtil.RTrim( context.localUtil.Format( A26FlyghtArrivalAirportName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlyghtArrivalAirportName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlyghtArrivalAirportName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Flyght.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFlyghtPrice_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlyghtPrice_Internalname, "Price", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFlyghtPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A27FlyghtPrice, 9, 2, ".", "")), StringUtil.LTrim( ((edtFlyghtPrice_Enabled!=0) ? context.localUtil.Format( A27FlyghtPrice, "ZZZZZ9.99") : context.localUtil.Format( A27FlyghtPrice, "ZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlyghtPrice_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlyghtPrice_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Price", "end", false, "", "HLP_Flyght.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFlyghtPricePercentage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlyghtPricePercentage_Internalname, "Price Percentage", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFlyghtPricePercentage_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A28FlyghtPricePercentage), 3, 0, ".", "")), StringUtil.LTrim( ((edtFlyghtPricePercentage_Enabled!=0) ? context.localUtil.Format( (decimal)(A28FlyghtPricePercentage), "ZZ9") : context.localUtil.Format( (decimal)(A28FlyghtPricePercentage), "ZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlyghtPricePercentage_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlyghtPricePercentage_Enabled, 0, "text", "1", 3, "chr", 1, "row", 3, 0, 0, 0, 0, -1, 0, true, "Percentage", "end", false, "", "HLP_Flyght.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAirlineID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAirlineID_Internalname, "Airline ID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAirlineID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A30AirlineID), 4, 0, ".", "")), StringUtil.LTrim( ((edtAirlineID_Enabled!=0) ? context.localUtil.Format( (decimal)(A30AirlineID), "ZZZ9") : context.localUtil.Format( (decimal)(A30AirlineID), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAirlineID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAirlineID_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Flyght.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_30_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_30_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_30_Internalname, sImgUrl, imgprompt_30_Link, "", "", context.GetTheme( ), imgprompt_30_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Flyght.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAirlineName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAirlineName_Internalname, "Airline Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtAirlineName_Internalname, StringUtil.RTrim( A31AirlineName), StringUtil.RTrim( context.localUtil.Format( A31AirlineName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAirlineName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAirlineName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "Name", "start", true, "", "HLP_Flyght.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAirlineDiscountPercentage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAirlineDiscountPercentage_Internalname, "Airline Discount Percentage", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtAirlineDiscountPercentage_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A32AirlineDiscountPercentage), 3, 0, ".", "")), StringUtil.LTrim( ((edtAirlineDiscountPercentage_Enabled!=0) ? context.localUtil.Format( (decimal)(A32AirlineDiscountPercentage), "ZZ9") : context.localUtil.Format( (decimal)(A32AirlineDiscountPercentage), "ZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAirlineDiscountPercentage_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAirlineDiscountPercentage_Enabled, 0, "text", "1", 3, "chr", 1, "row", 3, 0, 0, 0, 0, -1, 0, true, "Percentage", "end", false, "", "HLP_Flyght.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFlyghtFinalPrice_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlyghtFinalPrice_Internalname, "Final Price", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtFlyghtFinalPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A29FlyghtFinalPrice, 9, 2, ".", "")), StringUtil.LTrim( ((edtFlyghtFinalPrice_Enabled!=0) ? context.localUtil.Format( A29FlyghtFinalPrice, "ZZZZZ9.99") : context.localUtil.Format( A29FlyghtFinalPrice, "ZZZZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlyghtFinalPrice_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlyghtFinalPrice_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Price", "end", false, "", "HLP_Flyght.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFlyghtCapacity_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlyghtCapacity_Internalname, "Capacity", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtFlyghtCapacity_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A36FlyghtCapacity), 4, 0, ".", "")), StringUtil.LTrim( ((edtFlyghtCapacity_Enabled!=0) ? context.localUtil.Format( (decimal)(A36FlyghtCapacity), "ZZZ9") : context.localUtil.Format( (decimal)(A36FlyghtCapacity), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlyghtCapacity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlyghtCapacity_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Flyght.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSeattable_Internalname, 1, 0, "px", 0, "px", "form__table-level", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitleseat_Internalname, "Seat", "", "", lblTitleseat_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-04", 0, "", 1, 1, 0, 0, "HLP_Flyght.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         gxdraw_Gridflyght_seat( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Flyght.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Flyght.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Flyght.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridflyght_seat( )
      {
         /*  Grid Control  */
         StartGridControl98( ) ;
         nGXsfl_98_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount11 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_11 = 1;
               ScanStart0511( ) ;
               while ( RcdFound11 != 0 )
               {
                  init_level_properties11( ) ;
                  getByPrimaryKey0511( ) ;
                  AddRow0511( ) ;
                  ScanNext0511( ) ;
               }
               ScanEnd0511( ) ;
               nBlankRcdCount11 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B36FlyghtCapacity = A36FlyghtCapacity;
            n36FlyghtCapacity = false;
            AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
            standaloneNotModal0511( ) ;
            standaloneModal0511( ) ;
            sMode11 = Gx_mode;
            while ( nGXsfl_98_idx < nRC_GXsfl_98 )
            {
               bGXsfl_98_Refreshing = true;
               ReadRow0511( ) ;
               edtFlyghtSeatId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "FLYGHTSEATID_"+sGXsfl_98_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtFlyghtSeatId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlyghtSeatId_Enabled), 5, 0), !bGXsfl_98_Refreshing);
               cmbFlyghtSeatChar.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "FLYGHTSEATCHAR_"+sGXsfl_98_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbFlyghtSeatChar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbFlyghtSeatChar.Enabled), 5, 0), !bGXsfl_98_Refreshing);
               cmbFlyghtSeatLocation.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "FLYGHTSEATLOCATION_"+sGXsfl_98_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbFlyghtSeatLocation_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbFlyghtSeatLocation.Enabled), 5, 0), !bGXsfl_98_Refreshing);
               if ( ( nRcdExists_11 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0511( ) ;
               }
               SendRow0511( ) ;
               bGXsfl_98_Refreshing = false;
            }
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A36FlyghtCapacity = B36FlyghtCapacity;
            n36FlyghtCapacity = false;
            AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount11 = 5;
            nRcdExists_11 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0511( ) ;
               while ( RcdFound11 != 0 )
               {
                  sGXsfl_98_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_98_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_9811( ) ;
                  init_level_properties11( ) ;
                  standaloneNotModal0511( ) ;
                  getByPrimaryKey0511( ) ;
                  standaloneModal0511( ) ;
                  AddRow0511( ) ;
                  ScanNext0511( ) ;
               }
               ScanEnd0511( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         sMode11 = Gx_mode;
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sGXsfl_98_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_98_idx+1), 4, 0), 4, "0");
         SubsflControlProps_9811( ) ;
         InitAll0511( ) ;
         init_level_properties11( ) ;
         B36FlyghtCapacity = A36FlyghtCapacity;
         n36FlyghtCapacity = false;
         AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
         nRcdExists_11 = 0;
         nIsMod_11 = 0;
         nRcdDeleted_11 = 0;
         nBlankRcdCount11 = (short)(nBlankRcdUsr11+nBlankRcdCount11);
         fRowAdded = 0;
         while ( nBlankRcdCount11 > 0 )
         {
            standaloneNotModal0511( ) ;
            standaloneModal0511( ) ;
            AddRow0511( ) ;
            if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
            {
               fRowAdded = 1;
               GX_FocusControl = edtFlyghtSeatId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nBlankRcdCount11 = (short)(nBlankRcdCount11-1);
         }
         Gx_mode = sMode11;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         A36FlyghtCapacity = B36FlyghtCapacity;
         n36FlyghtCapacity = false;
         AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridflyght_seatContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridflyght_seat", Gridflyght_seatContainer, subGridflyght_seat_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridflyght_seatContainerData", Gridflyght_seatContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridflyght_seatContainerData"+"V", Gridflyght_seatContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridflyght_seatContainerData"+"V"+"\" value='"+Gridflyght_seatContainer.GridValuesHidden()+"'/>") ;
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
            Z20FlyghtId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z20FlyghtId"), ".", ","), 18, MidpointRounding.ToEven));
            Z27FlyghtPrice = context.localUtil.CToN( cgiGet( "Z27FlyghtPrice"), ".", ",");
            Z28FlyghtPricePercentage = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z28FlyghtPricePercentage"), ".", ","), 18, MidpointRounding.ToEven));
            Z30AirlineID = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z30AirlineID"), ".", ","), 18, MidpointRounding.ToEven));
            n30AirlineID = ((0==A30AirlineID) ? true : false);
            Z22FlyghtDepartureAirportId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z22FlyghtDepartureAirportId"), ".", ","), 18, MidpointRounding.ToEven));
            Z25FlyghtArrivalAirportId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z25FlyghtArrivalAirportId"), ".", ","), 18, MidpointRounding.ToEven));
            O36FlyghtCapacity = (short)(Math.Round(context.localUtil.CToN( cgiGet( "O36FlyghtCapacity"), ".", ","), 18, MidpointRounding.ToEven));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            nRC_GXsfl_98 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_98"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtFlyghtId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFlyghtId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FLYGHTID");
               AnyError = 1;
               GX_FocusControl = edtFlyghtId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A20FlyghtId = 0;
               AssignAttri("", false, "A20FlyghtId", StringUtil.LTrimStr( (decimal)(A20FlyghtId), 4, 0));
            }
            else
            {
               A20FlyghtId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtFlyghtId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A20FlyghtId", StringUtil.LTrimStr( (decimal)(A20FlyghtId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtFlyghtDepartureAirportId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFlyghtDepartureAirportId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FLYGHTDEPARTUREAIRPORTID");
               AnyError = 1;
               GX_FocusControl = edtFlyghtDepartureAirportId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A22FlyghtDepartureAirportId = 0;
               AssignAttri("", false, "A22FlyghtDepartureAirportId", StringUtil.LTrimStr( (decimal)(A22FlyghtDepartureAirportId), 4, 0));
            }
            else
            {
               A22FlyghtDepartureAirportId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtFlyghtDepartureAirportId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A22FlyghtDepartureAirportId", StringUtil.LTrimStr( (decimal)(A22FlyghtDepartureAirportId), 4, 0));
            }
            A23FlyghtDepartureAirportName = cgiGet( edtFlyghtDepartureAirportName_Internalname);
            AssignAttri("", false, "A23FlyghtDepartureAirportName", A23FlyghtDepartureAirportName);
            if ( ( ( context.localUtil.CToN( cgiGet( edtFlyghtArrivalAirportId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFlyghtArrivalAirportId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FLYGHTARRIVALAIRPORTID");
               AnyError = 1;
               GX_FocusControl = edtFlyghtArrivalAirportId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A25FlyghtArrivalAirportId = 0;
               AssignAttri("", false, "A25FlyghtArrivalAirportId", StringUtil.LTrimStr( (decimal)(A25FlyghtArrivalAirportId), 4, 0));
            }
            else
            {
               A25FlyghtArrivalAirportId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtFlyghtArrivalAirportId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A25FlyghtArrivalAirportId", StringUtil.LTrimStr( (decimal)(A25FlyghtArrivalAirportId), 4, 0));
            }
            A26FlyghtArrivalAirportName = cgiGet( edtFlyghtArrivalAirportName_Internalname);
            AssignAttri("", false, "A26FlyghtArrivalAirportName", A26FlyghtArrivalAirportName);
            if ( ( ( context.localUtil.CToN( cgiGet( edtFlyghtPrice_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFlyghtPrice_Internalname), ".", ",") > 999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FLYGHTPRICE");
               AnyError = 1;
               GX_FocusControl = edtFlyghtPrice_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A27FlyghtPrice = 0;
               AssignAttri("", false, "A27FlyghtPrice", StringUtil.LTrimStr( A27FlyghtPrice, 9, 2));
            }
            else
            {
               A27FlyghtPrice = context.localUtil.CToN( cgiGet( edtFlyghtPrice_Internalname), ".", ",");
               AssignAttri("", false, "A27FlyghtPrice", StringUtil.LTrimStr( A27FlyghtPrice, 9, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtFlyghtPricePercentage_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFlyghtPricePercentage_Internalname), ".", ",") > Convert.ToDecimal( 999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FLYGHTPRICEPERCENTAGE");
               AnyError = 1;
               GX_FocusControl = edtFlyghtPricePercentage_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A28FlyghtPricePercentage = 0;
               AssignAttri("", false, "A28FlyghtPricePercentage", StringUtil.LTrimStr( (decimal)(A28FlyghtPricePercentage), 3, 0));
            }
            else
            {
               A28FlyghtPricePercentage = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtFlyghtPricePercentage_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A28FlyghtPricePercentage", StringUtil.LTrimStr( (decimal)(A28FlyghtPricePercentage), 3, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtAirlineID_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAirlineID_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "AIRLINEID");
               AnyError = 1;
               GX_FocusControl = edtAirlineID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A30AirlineID = 0;
               n30AirlineID = false;
               AssignAttri("", false, "A30AirlineID", StringUtil.LTrimStr( (decimal)(A30AirlineID), 4, 0));
            }
            else
            {
               A30AirlineID = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtAirlineID_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               n30AirlineID = false;
               AssignAttri("", false, "A30AirlineID", StringUtil.LTrimStr( (decimal)(A30AirlineID), 4, 0));
            }
            n30AirlineID = ((0==A30AirlineID) ? true : false);
            A31AirlineName = cgiGet( edtAirlineName_Internalname);
            AssignAttri("", false, "A31AirlineName", A31AirlineName);
            A32AirlineDiscountPercentage = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtAirlineDiscountPercentage_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A32AirlineDiscountPercentage", StringUtil.LTrimStr( (decimal)(A32AirlineDiscountPercentage), 3, 0));
            A29FlyghtFinalPrice = context.localUtil.CToN( cgiGet( edtFlyghtFinalPrice_Internalname), ".", ",");
            AssignAttri("", false, "A29FlyghtFinalPrice", StringUtil.LTrimStr( A29FlyghtFinalPrice, 9, 2));
            A36FlyghtCapacity = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtFlyghtCapacity_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            n36FlyghtCapacity = false;
            AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
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
               A20FlyghtId = (short)(Math.Round(NumberUtil.Val( GetPar( "FlyghtId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A20FlyghtId", StringUtil.LTrimStr( (decimal)(A20FlyghtId), 4, 0));
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
               InitAll058( ) ;
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
         DisableAttributes058( ) ;
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

      protected void CONFIRM_0511( )
      {
         s36FlyghtCapacity = O36FlyghtCapacity;
         n36FlyghtCapacity = false;
         AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
         nGXsfl_98_idx = 0;
         while ( nGXsfl_98_idx < nRC_GXsfl_98 )
         {
            ReadRow0511( ) ;
            if ( ( nRcdExists_11 != 0 ) || ( nIsMod_11 != 0 ) )
            {
               GetKey0511( ) ;
               if ( ( nRcdExists_11 == 0 ) && ( nRcdDeleted_11 == 0 ) )
               {
                  if ( RcdFound11 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0511( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0511( ) ;
                        CloseExtendedTableCursors0511( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O36FlyghtCapacity = A36FlyghtCapacity;
                        n36FlyghtCapacity = false;
                        AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
                     }
                  }
                  else
                  {
                     GXCCtl = "FLYGHTSEATID_" + sGXsfl_98_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtFlyghtSeatId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound11 != 0 )
                  {
                     if ( nRcdDeleted_11 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0511( ) ;
                        Load0511( ) ;
                        BeforeValidate0511( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0511( ) ;
                           O36FlyghtCapacity = A36FlyghtCapacity;
                           n36FlyghtCapacity = false;
                           AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
                        }
                     }
                     else
                     {
                        if ( nIsMod_11 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0511( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0511( ) ;
                              CloseExtendedTableCursors0511( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O36FlyghtCapacity = A36FlyghtCapacity;
                              n36FlyghtCapacity = false;
                              AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_11 == 0 )
                     {
                        GXCCtl = "FLYGHTSEATID_" + sGXsfl_98_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtFlyghtSeatId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtFlyghtSeatId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A33FlyghtSeatId), 4, 0, ".", ""))) ;
            ChangePostValue( cmbFlyghtSeatChar_Internalname, StringUtil.RTrim( A35FlyghtSeatChar)) ;
            ChangePostValue( cmbFlyghtSeatLocation_Internalname, StringUtil.RTrim( A34FlyghtSeatLocation)) ;
            ChangePostValue( "ZT_"+"Z33FlyghtSeatId_"+sGXsfl_98_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z33FlyghtSeatId), 4, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z35FlyghtSeatChar_"+sGXsfl_98_idx, StringUtil.RTrim( Z35FlyghtSeatChar)) ;
            ChangePostValue( "ZT_"+"Z34FlyghtSeatLocation_"+sGXsfl_98_idx, StringUtil.RTrim( Z34FlyghtSeatLocation)) ;
            ChangePostValue( "nRcdDeleted_11_"+sGXsfl_98_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_11), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_11_"+sGXsfl_98_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_11), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_11_"+sGXsfl_98_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_11), 4, 0, ".", ""))) ;
            if ( nIsMod_11 != 0 )
            {
               ChangePostValue( "FLYGHTSEATID_"+sGXsfl_98_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtFlyghtSeatId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "FLYGHTSEATCHAR_"+sGXsfl_98_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbFlyghtSeatChar.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "FLYGHTSEATLOCATION_"+sGXsfl_98_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbFlyghtSeatLocation.Enabled), 5, 0, ".", ""))) ;
            }
         }
         O36FlyghtCapacity = s36FlyghtCapacity;
         n36FlyghtCapacity = false;
         AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
         /* Start of After( level) rules */
         if ( A36FlyghtCapacity < 8 )
         {
            GX_msglist.addItem("La cantidad de asientos no puede ser menor que 8", 1, "");
            AnyError = 1;
         }
         /* End of After( level) rules */
      }

      protected void ResetCaption050( )
      {
      }

      protected void ZM058( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z27FlyghtPrice = T00055_A27FlyghtPrice[0];
               Z28FlyghtPricePercentage = T00055_A28FlyghtPricePercentage[0];
               Z30AirlineID = T00055_A30AirlineID[0];
               Z22FlyghtDepartureAirportId = T00055_A22FlyghtDepartureAirportId[0];
               Z25FlyghtArrivalAirportId = T00055_A25FlyghtArrivalAirportId[0];
            }
            else
            {
               Z27FlyghtPrice = A27FlyghtPrice;
               Z28FlyghtPricePercentage = A28FlyghtPricePercentage;
               Z30AirlineID = A30AirlineID;
               Z22FlyghtDepartureAirportId = A22FlyghtDepartureAirportId;
               Z25FlyghtArrivalAirportId = A25FlyghtArrivalAirportId;
            }
         }
         if ( GX_JID == -6 )
         {
            Z20FlyghtId = A20FlyghtId;
            Z27FlyghtPrice = A27FlyghtPrice;
            Z28FlyghtPricePercentage = A28FlyghtPricePercentage;
            Z30AirlineID = A30AirlineID;
            Z22FlyghtDepartureAirportId = A22FlyghtDepartureAirportId;
            Z25FlyghtArrivalAirportId = A25FlyghtArrivalAirportId;
            Z36FlyghtCapacity = A36FlyghtCapacity;
            Z23FlyghtDepartureAirportName = A23FlyghtDepartureAirportName;
            Z26FlyghtArrivalAirportName = A26FlyghtArrivalAirportName;
            Z31AirlineName = A31AirlineName;
            Z32AirlineDiscountPercentage = A32AirlineDiscountPercentage;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_22_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0070.aspx"+"',["+"{Ctrl:gx.dom.el('"+"FLYGHTDEPARTUREAIRPORTID"+"'), id:'"+"FLYGHTDEPARTUREAIRPORTID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_25_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0070.aspx"+"',["+"{Ctrl:gx.dom.el('"+"FLYGHTARRIVALAIRPORTID"+"'), id:'"+"FLYGHTARRIVALAIRPORTID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_30_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0090.aspx"+"',["+"{Ctrl:gx.dom.el('"+"AIRLINEID"+"'), id:'"+"AIRLINEID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
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

      protected void Load058( )
      {
         /* Using cursor T000512 */
         pr_default.execute(8, new Object[] {A20FlyghtId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound8 = 1;
            A23FlyghtDepartureAirportName = T000512_A23FlyghtDepartureAirportName[0];
            AssignAttri("", false, "A23FlyghtDepartureAirportName", A23FlyghtDepartureAirportName);
            A26FlyghtArrivalAirportName = T000512_A26FlyghtArrivalAirportName[0];
            AssignAttri("", false, "A26FlyghtArrivalAirportName", A26FlyghtArrivalAirportName);
            A27FlyghtPrice = T000512_A27FlyghtPrice[0];
            AssignAttri("", false, "A27FlyghtPrice", StringUtil.LTrimStr( A27FlyghtPrice, 9, 2));
            A28FlyghtPricePercentage = T000512_A28FlyghtPricePercentage[0];
            AssignAttri("", false, "A28FlyghtPricePercentage", StringUtil.LTrimStr( (decimal)(A28FlyghtPricePercentage), 3, 0));
            A31AirlineName = T000512_A31AirlineName[0];
            AssignAttri("", false, "A31AirlineName", A31AirlineName);
            A32AirlineDiscountPercentage = T000512_A32AirlineDiscountPercentage[0];
            AssignAttri("", false, "A32AirlineDiscountPercentage", StringUtil.LTrimStr( (decimal)(A32AirlineDiscountPercentage), 3, 0));
            A30AirlineID = T000512_A30AirlineID[0];
            n30AirlineID = T000512_n30AirlineID[0];
            AssignAttri("", false, "A30AirlineID", StringUtil.LTrimStr( (decimal)(A30AirlineID), 4, 0));
            A22FlyghtDepartureAirportId = T000512_A22FlyghtDepartureAirportId[0];
            AssignAttri("", false, "A22FlyghtDepartureAirportId", StringUtil.LTrimStr( (decimal)(A22FlyghtDepartureAirportId), 4, 0));
            A25FlyghtArrivalAirportId = T000512_A25FlyghtArrivalAirportId[0];
            AssignAttri("", false, "A25FlyghtArrivalAirportId", StringUtil.LTrimStr( (decimal)(A25FlyghtArrivalAirportId), 4, 0));
            A36FlyghtCapacity = T000512_A36FlyghtCapacity[0];
            n36FlyghtCapacity = T000512_n36FlyghtCapacity[0];
            AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
            ZM058( -6) ;
         }
         pr_default.close(8);
         OnLoadActions058( ) ;
      }

      protected void OnLoadActions058( )
      {
         O36FlyghtCapacity = A36FlyghtCapacity;
         n36FlyghtCapacity = false;
         AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
         if ( A32AirlineDiscountPercentage > A28FlyghtPricePercentage )
         {
            A29FlyghtFinalPrice = (decimal)(A27FlyghtPrice*(1-A32AirlineDiscountPercentage/ (decimal)(100)));
            AssignAttri("", false, "A29FlyghtFinalPrice", StringUtil.LTrimStr( A29FlyghtFinalPrice, 9, 2));
         }
         else
         {
            if ( A32AirlineDiscountPercentage < A28FlyghtPricePercentage )
            {
               A29FlyghtFinalPrice = (decimal)(A27FlyghtPrice*(1-A28FlyghtPricePercentage/ (decimal)(100)));
               AssignAttri("", false, "A29FlyghtFinalPrice", StringUtil.LTrimStr( A29FlyghtFinalPrice, 9, 2));
            }
            else
            {
               A29FlyghtFinalPrice = 0;
               AssignAttri("", false, "A29FlyghtFinalPrice", StringUtil.LTrimStr( A29FlyghtFinalPrice, 9, 2));
            }
         }
      }

      protected void CheckExtendedTable058( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000510 */
         pr_default.execute(7, new Object[] {A20FlyghtId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            A36FlyghtCapacity = T000510_A36FlyghtCapacity[0];
            n36FlyghtCapacity = T000510_n36FlyghtCapacity[0];
            AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
         }
         else
         {
            A36FlyghtCapacity = 0;
            n36FlyghtCapacity = false;
            AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
         }
         pr_default.close(7);
         /* Using cursor T00057 */
         pr_default.execute(5, new Object[] {A22FlyghtDepartureAirportId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No matching 'Flyght Departure Airport'.", "ForeignKeyNotFound", 1, "FLYGHTDEPARTUREAIRPORTID");
            AnyError = 1;
            GX_FocusControl = edtFlyghtDepartureAirportId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A23FlyghtDepartureAirportName = T00057_A23FlyghtDepartureAirportName[0];
         AssignAttri("", false, "A23FlyghtDepartureAirportName", A23FlyghtDepartureAirportName);
         pr_default.close(5);
         /* Using cursor T00058 */
         pr_default.execute(6, new Object[] {A25FlyghtArrivalAirportId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No matching 'Flyght Arrival Airport'.", "ForeignKeyNotFound", 1, "FLYGHTARRIVALAIRPORTID");
            AnyError = 1;
            GX_FocusControl = edtFlyghtArrivalAirportId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A26FlyghtArrivalAirportName = T00058_A26FlyghtArrivalAirportName[0];
         AssignAttri("", false, "A26FlyghtArrivalAirportName", A26FlyghtArrivalAirportName);
         pr_default.close(6);
         /* Using cursor T00056 */
         pr_default.execute(4, new Object[] {n30AirlineID, A30AirlineID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A30AirlineID) ) )
            {
               GX_msglist.addItem("No matching 'Airline'.", "ForeignKeyNotFound", 1, "AIRLINEID");
               AnyError = 1;
               GX_FocusControl = edtAirlineID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A31AirlineName = T00056_A31AirlineName[0];
         AssignAttri("", false, "A31AirlineName", A31AirlineName);
         A32AirlineDiscountPercentage = T00056_A32AirlineDiscountPercentage[0];
         AssignAttri("", false, "A32AirlineDiscountPercentage", StringUtil.LTrimStr( (decimal)(A32AirlineDiscountPercentage), 3, 0));
         pr_default.close(4);
         if ( A32AirlineDiscountPercentage > A28FlyghtPricePercentage )
         {
            A29FlyghtFinalPrice = (decimal)(A27FlyghtPrice*(1-A32AirlineDiscountPercentage/ (decimal)(100)));
            AssignAttri("", false, "A29FlyghtFinalPrice", StringUtil.LTrimStr( A29FlyghtFinalPrice, 9, 2));
         }
         else
         {
            if ( A32AirlineDiscountPercentage < A28FlyghtPricePercentage )
            {
               A29FlyghtFinalPrice = (decimal)(A27FlyghtPrice*(1-A28FlyghtPricePercentage/ (decimal)(100)));
               AssignAttri("", false, "A29FlyghtFinalPrice", StringUtil.LTrimStr( A29FlyghtFinalPrice, 9, 2));
            }
            else
            {
               A29FlyghtFinalPrice = 0;
               AssignAttri("", false, "A29FlyghtFinalPrice", StringUtil.LTrimStr( A29FlyghtFinalPrice, 9, 2));
            }
         }
      }

      protected void CloseExtendedTableCursors058( )
      {
         pr_default.close(7);
         pr_default.close(5);
         pr_default.close(6);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_10( short A20FlyghtId )
      {
         /* Using cursor T000514 */
         pr_default.execute(9, new Object[] {A20FlyghtId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            A36FlyghtCapacity = T000514_A36FlyghtCapacity[0];
            n36FlyghtCapacity = T000514_n36FlyghtCapacity[0];
            AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
         }
         else
         {
            A36FlyghtCapacity = 0;
            n36FlyghtCapacity = false;
            AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A36FlyghtCapacity), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_8( short A22FlyghtDepartureAirportId )
      {
         /* Using cursor T000515 */
         pr_default.execute(10, new Object[] {A22FlyghtDepartureAirportId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No matching 'Flyght Departure Airport'.", "ForeignKeyNotFound", 1, "FLYGHTDEPARTUREAIRPORTID");
            AnyError = 1;
            GX_FocusControl = edtFlyghtDepartureAirportId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A23FlyghtDepartureAirportName = T000515_A23FlyghtDepartureAirportName[0];
         AssignAttri("", false, "A23FlyghtDepartureAirportName", A23FlyghtDepartureAirportName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A23FlyghtDepartureAirportName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_9( short A25FlyghtArrivalAirportId )
      {
         /* Using cursor T000516 */
         pr_default.execute(11, new Object[] {A25FlyghtArrivalAirportId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No matching 'Flyght Arrival Airport'.", "ForeignKeyNotFound", 1, "FLYGHTARRIVALAIRPORTID");
            AnyError = 1;
            GX_FocusControl = edtFlyghtArrivalAirportId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A26FlyghtArrivalAirportName = T000516_A26FlyghtArrivalAirportName[0];
         AssignAttri("", false, "A26FlyghtArrivalAirportName", A26FlyghtArrivalAirportName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A26FlyghtArrivalAirportName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void gxLoad_7( short A30AirlineID )
      {
         /* Using cursor T000517 */
         pr_default.execute(12, new Object[] {n30AirlineID, A30AirlineID});
         if ( (pr_default.getStatus(12) == 101) )
         {
            if ( ! ( (0==A30AirlineID) ) )
            {
               GX_msglist.addItem("No matching 'Airline'.", "ForeignKeyNotFound", 1, "AIRLINEID");
               AnyError = 1;
               GX_FocusControl = edtAirlineID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A31AirlineName = T000517_A31AirlineName[0];
         AssignAttri("", false, "A31AirlineName", A31AirlineName);
         A32AirlineDiscountPercentage = T000517_A32AirlineDiscountPercentage[0];
         AssignAttri("", false, "A32AirlineDiscountPercentage", StringUtil.LTrimStr( (decimal)(A32AirlineDiscountPercentage), 3, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A31AirlineName))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A32AirlineDiscountPercentage), 3, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void GetKey058( )
      {
         /* Using cursor T000518 */
         pr_default.execute(13, new Object[] {A20FlyghtId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound8 = 1;
         }
         else
         {
            RcdFound8 = 0;
         }
         pr_default.close(13);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00055 */
         pr_default.execute(3, new Object[] {A20FlyghtId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM058( 6) ;
            RcdFound8 = 1;
            A20FlyghtId = T00055_A20FlyghtId[0];
            AssignAttri("", false, "A20FlyghtId", StringUtil.LTrimStr( (decimal)(A20FlyghtId), 4, 0));
            A27FlyghtPrice = T00055_A27FlyghtPrice[0];
            AssignAttri("", false, "A27FlyghtPrice", StringUtil.LTrimStr( A27FlyghtPrice, 9, 2));
            A28FlyghtPricePercentage = T00055_A28FlyghtPricePercentage[0];
            AssignAttri("", false, "A28FlyghtPricePercentage", StringUtil.LTrimStr( (decimal)(A28FlyghtPricePercentage), 3, 0));
            A30AirlineID = T00055_A30AirlineID[0];
            n30AirlineID = T00055_n30AirlineID[0];
            AssignAttri("", false, "A30AirlineID", StringUtil.LTrimStr( (decimal)(A30AirlineID), 4, 0));
            A22FlyghtDepartureAirportId = T00055_A22FlyghtDepartureAirportId[0];
            AssignAttri("", false, "A22FlyghtDepartureAirportId", StringUtil.LTrimStr( (decimal)(A22FlyghtDepartureAirportId), 4, 0));
            A25FlyghtArrivalAirportId = T00055_A25FlyghtArrivalAirportId[0];
            AssignAttri("", false, "A25FlyghtArrivalAirportId", StringUtil.LTrimStr( (decimal)(A25FlyghtArrivalAirportId), 4, 0));
            Z20FlyghtId = A20FlyghtId;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load058( ) ;
            if ( AnyError == 1 )
            {
               RcdFound8 = 0;
               InitializeNonKey058( ) ;
            }
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound8 = 0;
            InitializeNonKey058( ) ;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey058( ) ;
         if ( RcdFound8 == 0 )
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
         RcdFound8 = 0;
         /* Using cursor T000519 */
         pr_default.execute(14, new Object[] {A20FlyghtId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            while ( (pr_default.getStatus(14) != 101) && ( ( T000519_A20FlyghtId[0] < A20FlyghtId ) ) )
            {
               pr_default.readNext(14);
            }
            if ( (pr_default.getStatus(14) != 101) && ( ( T000519_A20FlyghtId[0] > A20FlyghtId ) ) )
            {
               A20FlyghtId = T000519_A20FlyghtId[0];
               AssignAttri("", false, "A20FlyghtId", StringUtil.LTrimStr( (decimal)(A20FlyghtId), 4, 0));
               RcdFound8 = 1;
            }
         }
         pr_default.close(14);
      }

      protected void move_previous( )
      {
         RcdFound8 = 0;
         /* Using cursor T000520 */
         pr_default.execute(15, new Object[] {A20FlyghtId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            while ( (pr_default.getStatus(15) != 101) && ( ( T000520_A20FlyghtId[0] > A20FlyghtId ) ) )
            {
               pr_default.readNext(15);
            }
            if ( (pr_default.getStatus(15) != 101) && ( ( T000520_A20FlyghtId[0] < A20FlyghtId ) ) )
            {
               A20FlyghtId = T000520_A20FlyghtId[0];
               AssignAttri("", false, "A20FlyghtId", StringUtil.LTrimStr( (decimal)(A20FlyghtId), 4, 0));
               RcdFound8 = 1;
            }
         }
         pr_default.close(15);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey058( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A36FlyghtCapacity = O36FlyghtCapacity;
            n36FlyghtCapacity = false;
            AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
            GX_FocusControl = edtFlyghtId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert058( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound8 == 1 )
            {
               if ( A20FlyghtId != Z20FlyghtId )
               {
                  A20FlyghtId = Z20FlyghtId;
                  AssignAttri("", false, "A20FlyghtId", StringUtil.LTrimStr( (decimal)(A20FlyghtId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "FLYGHTID");
                  AnyError = 1;
                  GX_FocusControl = edtFlyghtId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  A36FlyghtCapacity = O36FlyghtCapacity;
                  n36FlyghtCapacity = false;
                  AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtFlyghtId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  A36FlyghtCapacity = O36FlyghtCapacity;
                  n36FlyghtCapacity = false;
                  AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
                  Update058( ) ;
                  GX_FocusControl = edtFlyghtId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A20FlyghtId != Z20FlyghtId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  A36FlyghtCapacity = O36FlyghtCapacity;
                  n36FlyghtCapacity = false;
                  AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
                  GX_FocusControl = edtFlyghtId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert058( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "FLYGHTID");
                     AnyError = 1;
                     GX_FocusControl = edtFlyghtId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     A36FlyghtCapacity = O36FlyghtCapacity;
                     n36FlyghtCapacity = false;
                     AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
                     GX_FocusControl = edtFlyghtId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert058( ) ;
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
         if ( A20FlyghtId != Z20FlyghtId )
         {
            A20FlyghtId = Z20FlyghtId;
            AssignAttri("", false, "A20FlyghtId", StringUtil.LTrimStr( (decimal)(A20FlyghtId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "FLYGHTID");
            AnyError = 1;
            GX_FocusControl = edtFlyghtId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            A36FlyghtCapacity = O36FlyghtCapacity;
            n36FlyghtCapacity = false;
            AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtFlyghtId_Internalname;
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
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "FLYGHTID");
            AnyError = 1;
            GX_FocusControl = edtFlyghtId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtFlyghtDepartureAirportId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart058( ) ;
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFlyghtDepartureAirportId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd058( ) ;
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
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFlyghtDepartureAirportId_Internalname;
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
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFlyghtDepartureAirportId_Internalname;
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
         ScanStart058( ) ;
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound8 != 0 )
            {
               ScanNext058( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFlyghtDepartureAirportId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd058( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency058( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00054 */
            pr_default.execute(2, new Object[] {A20FlyghtId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Flyght"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( Z27FlyghtPrice != T00054_A27FlyghtPrice[0] ) || ( Z28FlyghtPricePercentage != T00054_A28FlyghtPricePercentage[0] ) || ( Z30AirlineID != T00054_A30AirlineID[0] ) || ( Z22FlyghtDepartureAirportId != T00054_A22FlyghtDepartureAirportId[0] ) || ( Z25FlyghtArrivalAirportId != T00054_A25FlyghtArrivalAirportId[0] ) )
            {
               if ( Z27FlyghtPrice != T00054_A27FlyghtPrice[0] )
               {
                  GXUtil.WriteLog("flyght:[seudo value changed for attri]"+"FlyghtPrice");
                  GXUtil.WriteLogRaw("Old: ",Z27FlyghtPrice);
                  GXUtil.WriteLogRaw("Current: ",T00054_A27FlyghtPrice[0]);
               }
               if ( Z28FlyghtPricePercentage != T00054_A28FlyghtPricePercentage[0] )
               {
                  GXUtil.WriteLog("flyght:[seudo value changed for attri]"+"FlyghtPricePercentage");
                  GXUtil.WriteLogRaw("Old: ",Z28FlyghtPricePercentage);
                  GXUtil.WriteLogRaw("Current: ",T00054_A28FlyghtPricePercentage[0]);
               }
               if ( Z30AirlineID != T00054_A30AirlineID[0] )
               {
                  GXUtil.WriteLog("flyght:[seudo value changed for attri]"+"AirlineID");
                  GXUtil.WriteLogRaw("Old: ",Z30AirlineID);
                  GXUtil.WriteLogRaw("Current: ",T00054_A30AirlineID[0]);
               }
               if ( Z22FlyghtDepartureAirportId != T00054_A22FlyghtDepartureAirportId[0] )
               {
                  GXUtil.WriteLog("flyght:[seudo value changed for attri]"+"FlyghtDepartureAirportId");
                  GXUtil.WriteLogRaw("Old: ",Z22FlyghtDepartureAirportId);
                  GXUtil.WriteLogRaw("Current: ",T00054_A22FlyghtDepartureAirportId[0]);
               }
               if ( Z25FlyghtArrivalAirportId != T00054_A25FlyghtArrivalAirportId[0] )
               {
                  GXUtil.WriteLog("flyght:[seudo value changed for attri]"+"FlyghtArrivalAirportId");
                  GXUtil.WriteLogRaw("Old: ",Z25FlyghtArrivalAirportId);
                  GXUtil.WriteLogRaw("Current: ",T00054_A25FlyghtArrivalAirportId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Flyght"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert058( )
      {
         BeforeValidate058( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable058( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM058( 0) ;
            CheckOptimisticConcurrency058( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm058( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert058( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000521 */
                     pr_default.execute(16, new Object[] {A27FlyghtPrice, A28FlyghtPricePercentage, n30AirlineID, A30AirlineID, A22FlyghtDepartureAirportId, A25FlyghtArrivalAirportId});
                     A20FlyghtId = T000521_A20FlyghtId[0];
                     AssignAttri("", false, "A20FlyghtId", StringUtil.LTrimStr( (decimal)(A20FlyghtId), 4, 0));
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("Flyght");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel058( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption050( ) ;
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
               Load058( ) ;
            }
            EndLevel058( ) ;
         }
         CloseExtendedTableCursors058( ) ;
      }

      protected void Update058( )
      {
         BeforeValidate058( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable058( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency058( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm058( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate058( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000522 */
                     pr_default.execute(17, new Object[] {A27FlyghtPrice, A28FlyghtPricePercentage, n30AirlineID, A30AirlineID, A22FlyghtDepartureAirportId, A25FlyghtArrivalAirportId, A20FlyghtId});
                     pr_default.close(17);
                     pr_default.SmartCacheProvider.SetUpdated("Flyght");
                     if ( (pr_default.getStatus(17) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Flyght"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate058( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel058( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
                              ResetCaption050( ) ;
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
            EndLevel058( ) ;
         }
         CloseExtendedTableCursors058( ) ;
      }

      protected void DeferredUpdate058( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate058( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency058( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls058( ) ;
            AfterConfirm058( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete058( ) ;
               if ( AnyError == 0 )
               {
                  A36FlyghtCapacity = O36FlyghtCapacity;
                  n36FlyghtCapacity = false;
                  AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
                  ScanStart0511( ) ;
                  while ( RcdFound11 != 0 )
                  {
                     getByPrimaryKey0511( ) ;
                     Delete0511( ) ;
                     ScanNext0511( ) ;
                     O36FlyghtCapacity = A36FlyghtCapacity;
                     n36FlyghtCapacity = false;
                     AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
                  }
                  ScanEnd0511( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000523 */
                     pr_default.execute(18, new Object[] {A20FlyghtId});
                     pr_default.close(18);
                     pr_default.SmartCacheProvider.SetUpdated("Flyght");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           move_next( ) ;
                           if ( RcdFound8 == 0 )
                           {
                              InitAll058( ) ;
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
                           ResetCaption050( ) ;
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
         sMode8 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel058( ) ;
         Gx_mode = sMode8;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls058( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000525 */
            pr_default.execute(19, new Object[] {A20FlyghtId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               A36FlyghtCapacity = T000525_A36FlyghtCapacity[0];
               n36FlyghtCapacity = T000525_n36FlyghtCapacity[0];
               AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
            }
            else
            {
               A36FlyghtCapacity = 0;
               n36FlyghtCapacity = false;
               AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
            }
            pr_default.close(19);
            /* Using cursor T000526 */
            pr_default.execute(20, new Object[] {A22FlyghtDepartureAirportId});
            A23FlyghtDepartureAirportName = T000526_A23FlyghtDepartureAirportName[0];
            AssignAttri("", false, "A23FlyghtDepartureAirportName", A23FlyghtDepartureAirportName);
            pr_default.close(20);
            /* Using cursor T000527 */
            pr_default.execute(21, new Object[] {A25FlyghtArrivalAirportId});
            A26FlyghtArrivalAirportName = T000527_A26FlyghtArrivalAirportName[0];
            AssignAttri("", false, "A26FlyghtArrivalAirportName", A26FlyghtArrivalAirportName);
            pr_default.close(21);
            /* Using cursor T000528 */
            pr_default.execute(22, new Object[] {n30AirlineID, A30AirlineID});
            A31AirlineName = T000528_A31AirlineName[0];
            AssignAttri("", false, "A31AirlineName", A31AirlineName);
            A32AirlineDiscountPercentage = T000528_A32AirlineDiscountPercentage[0];
            AssignAttri("", false, "A32AirlineDiscountPercentage", StringUtil.LTrimStr( (decimal)(A32AirlineDiscountPercentage), 3, 0));
            pr_default.close(22);
            if ( A32AirlineDiscountPercentage > A28FlyghtPricePercentage )
            {
               A29FlyghtFinalPrice = (decimal)(A27FlyghtPrice*(1-A32AirlineDiscountPercentage/ (decimal)(100)));
               AssignAttri("", false, "A29FlyghtFinalPrice", StringUtil.LTrimStr( A29FlyghtFinalPrice, 9, 2));
            }
            else
            {
               if ( A32AirlineDiscountPercentage < A28FlyghtPricePercentage )
               {
                  A29FlyghtFinalPrice = (decimal)(A27FlyghtPrice*(1-A28FlyghtPricePercentage/ (decimal)(100)));
                  AssignAttri("", false, "A29FlyghtFinalPrice", StringUtil.LTrimStr( A29FlyghtFinalPrice, 9, 2));
               }
               else
               {
                  A29FlyghtFinalPrice = 0;
                  AssignAttri("", false, "A29FlyghtFinalPrice", StringUtil.LTrimStr( A29FlyghtFinalPrice, 9, 2));
               }
            }
         }
      }

      protected void ProcessNestedLevel0511( )
      {
         s36FlyghtCapacity = O36FlyghtCapacity;
         n36FlyghtCapacity = false;
         AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
         nGXsfl_98_idx = 0;
         while ( nGXsfl_98_idx < nRC_GXsfl_98 )
         {
            ReadRow0511( ) ;
            if ( ( nRcdExists_11 != 0 ) || ( nIsMod_11 != 0 ) )
            {
               standaloneNotModal0511( ) ;
               GetKey0511( ) ;
               if ( ( nRcdExists_11 == 0 ) && ( nRcdDeleted_11 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0511( ) ;
               }
               else
               {
                  if ( RcdFound11 != 0 )
                  {
                     if ( ( nRcdDeleted_11 != 0 ) && ( nRcdExists_11 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0511( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_11 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0511( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_11 == 0 )
                     {
                        GXCCtl = "FLYGHTSEATID_" + sGXsfl_98_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtFlyghtSeatId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
               O36FlyghtCapacity = A36FlyghtCapacity;
               n36FlyghtCapacity = false;
               AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
            }
            ChangePostValue( edtFlyghtSeatId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A33FlyghtSeatId), 4, 0, ".", ""))) ;
            ChangePostValue( cmbFlyghtSeatChar_Internalname, StringUtil.RTrim( A35FlyghtSeatChar)) ;
            ChangePostValue( cmbFlyghtSeatLocation_Internalname, StringUtil.RTrim( A34FlyghtSeatLocation)) ;
            ChangePostValue( "ZT_"+"Z33FlyghtSeatId_"+sGXsfl_98_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z33FlyghtSeatId), 4, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z35FlyghtSeatChar_"+sGXsfl_98_idx, StringUtil.RTrim( Z35FlyghtSeatChar)) ;
            ChangePostValue( "ZT_"+"Z34FlyghtSeatLocation_"+sGXsfl_98_idx, StringUtil.RTrim( Z34FlyghtSeatLocation)) ;
            ChangePostValue( "nRcdDeleted_11_"+sGXsfl_98_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_11), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_11_"+sGXsfl_98_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_11), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_11_"+sGXsfl_98_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_11), 4, 0, ".", ""))) ;
            if ( nIsMod_11 != 0 )
            {
               ChangePostValue( "FLYGHTSEATID_"+sGXsfl_98_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtFlyghtSeatId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "FLYGHTSEATCHAR_"+sGXsfl_98_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbFlyghtSeatChar.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "FLYGHTSEATLOCATION_"+sGXsfl_98_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbFlyghtSeatLocation.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         if ( A36FlyghtCapacity < 8 )
         {
            GX_msglist.addItem("La cantidad de asientos no puede ser menor que 8", 1, "");
            AnyError = 1;
         }
         /* End of After( level) rules */
         InitAll0511( ) ;
         if ( AnyError != 0 )
         {
            O36FlyghtCapacity = s36FlyghtCapacity;
            n36FlyghtCapacity = false;
            AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
         }
         nRcdExists_11 = 0;
         nIsMod_11 = 0;
         nRcdDeleted_11 = 0;
      }

      protected void ProcessLevel058( )
      {
         /* Save parent mode. */
         sMode8 = Gx_mode;
         ProcessNestedLevel0511( ) ;
         if ( AnyError != 0 )
         {
            O36FlyghtCapacity = s36FlyghtCapacity;
            n36FlyghtCapacity = false;
            AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
         }
         /* Restore parent mode. */
         Gx_mode = sMode8;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel058( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete058( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(22);
            pr_default.close(20);
            pr_default.close(21);
            pr_default.close(19);
            context.CommitDataStores("flyght",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues050( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(22);
            pr_default.close(20);
            pr_default.close(21);
            pr_default.close(19);
            context.RollbackDataStores("flyght",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart058( )
      {
         /* Using cursor T000529 */
         pr_default.execute(23);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound8 = 1;
            A20FlyghtId = T000529_A20FlyghtId[0];
            AssignAttri("", false, "A20FlyghtId", StringUtil.LTrimStr( (decimal)(A20FlyghtId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext058( )
      {
         /* Scan next routine */
         pr_default.readNext(23);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound8 = 1;
            A20FlyghtId = T000529_A20FlyghtId[0];
            AssignAttri("", false, "A20FlyghtId", StringUtil.LTrimStr( (decimal)(A20FlyghtId), 4, 0));
         }
      }

      protected void ScanEnd058( )
      {
         pr_default.close(23);
      }

      protected void AfterConfirm058( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert058( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate058( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete058( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete058( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate058( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes058( )
      {
         edtFlyghtId_Enabled = 0;
         AssignProp("", false, edtFlyghtId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlyghtId_Enabled), 5, 0), true);
         edtFlyghtDepartureAirportId_Enabled = 0;
         AssignProp("", false, edtFlyghtDepartureAirportId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlyghtDepartureAirportId_Enabled), 5, 0), true);
         edtFlyghtDepartureAirportName_Enabled = 0;
         AssignProp("", false, edtFlyghtDepartureAirportName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlyghtDepartureAirportName_Enabled), 5, 0), true);
         edtFlyghtArrivalAirportId_Enabled = 0;
         AssignProp("", false, edtFlyghtArrivalAirportId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlyghtArrivalAirportId_Enabled), 5, 0), true);
         edtFlyghtArrivalAirportName_Enabled = 0;
         AssignProp("", false, edtFlyghtArrivalAirportName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlyghtArrivalAirportName_Enabled), 5, 0), true);
         edtFlyghtPrice_Enabled = 0;
         AssignProp("", false, edtFlyghtPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlyghtPrice_Enabled), 5, 0), true);
         edtFlyghtPricePercentage_Enabled = 0;
         AssignProp("", false, edtFlyghtPricePercentage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlyghtPricePercentage_Enabled), 5, 0), true);
         edtAirlineID_Enabled = 0;
         AssignProp("", false, edtAirlineID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAirlineID_Enabled), 5, 0), true);
         edtAirlineName_Enabled = 0;
         AssignProp("", false, edtAirlineName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAirlineName_Enabled), 5, 0), true);
         edtAirlineDiscountPercentage_Enabled = 0;
         AssignProp("", false, edtAirlineDiscountPercentage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAirlineDiscountPercentage_Enabled), 5, 0), true);
         edtFlyghtFinalPrice_Enabled = 0;
         AssignProp("", false, edtFlyghtFinalPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlyghtFinalPrice_Enabled), 5, 0), true);
         edtFlyghtCapacity_Enabled = 0;
         AssignProp("", false, edtFlyghtCapacity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlyghtCapacity_Enabled), 5, 0), true);
      }

      protected void ZM0511( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z34FlyghtSeatLocation = T00053_A34FlyghtSeatLocation[0];
            }
            else
            {
               Z34FlyghtSeatLocation = A34FlyghtSeatLocation;
            }
         }
         if ( GX_JID == -11 )
         {
            Z20FlyghtId = A20FlyghtId;
            Z33FlyghtSeatId = A33FlyghtSeatId;
            Z35FlyghtSeatChar = A35FlyghtSeatChar;
            Z34FlyghtSeatLocation = A34FlyghtSeatLocation;
         }
      }

      protected void standaloneNotModal0511( )
      {
      }

      protected void standaloneModal0511( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtFlyghtSeatId_Enabled = 0;
            AssignProp("", false, edtFlyghtSeatId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlyghtSeatId_Enabled), 5, 0), !bGXsfl_98_Refreshing);
         }
         else
         {
            edtFlyghtSeatId_Enabled = 1;
            AssignProp("", false, edtFlyghtSeatId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlyghtSeatId_Enabled), 5, 0), !bGXsfl_98_Refreshing);
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            cmbFlyghtSeatChar.Enabled = 0;
            AssignProp("", false, cmbFlyghtSeatChar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbFlyghtSeatChar.Enabled), 5, 0), !bGXsfl_98_Refreshing);
         }
         else
         {
            cmbFlyghtSeatChar.Enabled = 1;
            AssignProp("", false, cmbFlyghtSeatChar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbFlyghtSeatChar.Enabled), 5, 0), !bGXsfl_98_Refreshing);
         }
      }

      protected void Load0511( )
      {
         /* Using cursor T000530 */
         pr_default.execute(24, new Object[] {A20FlyghtId, A33FlyghtSeatId, A35FlyghtSeatChar});
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound11 = 1;
            A34FlyghtSeatLocation = T000530_A34FlyghtSeatLocation[0];
            ZM0511( -11) ;
         }
         pr_default.close(24);
         OnLoadActions0511( ) ;
      }

      protected void OnLoadActions0511( )
      {
         if ( IsIns( )  )
         {
            A36FlyghtCapacity = (short)(O36FlyghtCapacity+1);
            n36FlyghtCapacity = false;
            AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
         }
         else
         {
            if ( IsUpd( )  )
            {
               A36FlyghtCapacity = O36FlyghtCapacity;
               n36FlyghtCapacity = false;
               AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  A36FlyghtCapacity = (short)(O36FlyghtCapacity-1);
                  n36FlyghtCapacity = false;
                  AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
               }
            }
         }
      }

      protected void CheckExtendedTable0511( )
      {
         nIsDirty_11 = 0;
         Gx_BScreen = 1;
         standaloneModal0511( ) ;
         if ( ! ( ( StringUtil.StrCmp(A35FlyghtSeatChar, "A") == 0 ) || ( StringUtil.StrCmp(A35FlyghtSeatChar, "B") == 0 ) || ( StringUtil.StrCmp(A35FlyghtSeatChar, "C") == 0 ) || ( StringUtil.StrCmp(A35FlyghtSeatChar, "D") == 0 ) || ( StringUtil.StrCmp(A35FlyghtSeatChar, "E") == 0 ) || ( StringUtil.StrCmp(A35FlyghtSeatChar, "F") == 0 ) ) )
         {
            GXCCtl = "FLYGHTSEATCHAR_" + sGXsfl_98_idx;
            GX_msglist.addItem("Field Flyght Seat Char is out of range", "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = cmbFlyghtSeatChar_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A34FlyghtSeatLocation, "W") == 0 ) || ( StringUtil.StrCmp(A34FlyghtSeatLocation, "M") == 0 ) || ( StringUtil.StrCmp(A34FlyghtSeatLocation, "A") == 0 ) ) )
         {
            GXCCtl = "FLYGHTSEATLOCATION_" + sGXsfl_98_idx;
            GX_msglist.addItem("Field Flyght Seat Location is out of range", "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = cmbFlyghtSeatLocation_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( IsIns( )  )
         {
            nIsDirty_11 = 1;
            A36FlyghtCapacity = (short)(O36FlyghtCapacity+1);
            n36FlyghtCapacity = false;
            AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
         }
         else
         {
            if ( IsUpd( )  )
            {
               nIsDirty_11 = 1;
               A36FlyghtCapacity = O36FlyghtCapacity;
               n36FlyghtCapacity = false;
               AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  nIsDirty_11 = 1;
                  A36FlyghtCapacity = (short)(O36FlyghtCapacity-1);
                  n36FlyghtCapacity = false;
                  AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
               }
            }
         }
      }

      protected void CloseExtendedTableCursors0511( )
      {
      }

      protected void enableDisable0511( )
      {
      }

      protected void GetKey0511( )
      {
         /* Using cursor T000531 */
         pr_default.execute(25, new Object[] {A20FlyghtId, A33FlyghtSeatId, A35FlyghtSeatChar});
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound11 = 1;
         }
         else
         {
            RcdFound11 = 0;
         }
         pr_default.close(25);
      }

      protected void getByPrimaryKey0511( )
      {
         /* Using cursor T00053 */
         pr_default.execute(1, new Object[] {A20FlyghtId, A33FlyghtSeatId, A35FlyghtSeatChar});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0511( 11) ;
            RcdFound11 = 1;
            InitializeNonKey0511( ) ;
            A33FlyghtSeatId = T00053_A33FlyghtSeatId[0];
            A35FlyghtSeatChar = T00053_A35FlyghtSeatChar[0];
            A34FlyghtSeatLocation = T00053_A34FlyghtSeatLocation[0];
            Z20FlyghtId = A20FlyghtId;
            Z33FlyghtSeatId = A33FlyghtSeatId;
            Z35FlyghtSeatChar = A35FlyghtSeatChar;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0511( ) ;
            Load0511( ) ;
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound11 = 0;
            InitializeNonKey0511( ) ;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0511( ) ;
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0511( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0511( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00052 */
            pr_default.execute(0, new Object[] {A20FlyghtId, A33FlyghtSeatId, A35FlyghtSeatChar});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"FlyghtSeat"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z34FlyghtSeatLocation, T00052_A34FlyghtSeatLocation[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z34FlyghtSeatLocation, T00052_A34FlyghtSeatLocation[0]) != 0 )
               {
                  GXUtil.WriteLog("flyght:[seudo value changed for attri]"+"FlyghtSeatLocation");
                  GXUtil.WriteLogRaw("Old: ",Z34FlyghtSeatLocation);
                  GXUtil.WriteLogRaw("Current: ",T00052_A34FlyghtSeatLocation[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"FlyghtSeat"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0511( )
      {
         BeforeValidate0511( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0511( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0511( 0) ;
            CheckOptimisticConcurrency0511( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0511( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0511( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000532 */
                     pr_default.execute(26, new Object[] {A20FlyghtId, A33FlyghtSeatId, A35FlyghtSeatChar, A34FlyghtSeatLocation});
                     pr_default.close(26);
                     pr_default.SmartCacheProvider.SetUpdated("FlyghtSeat");
                     if ( (pr_default.getStatus(26) == 1) )
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
               Load0511( ) ;
            }
            EndLevel0511( ) ;
         }
         CloseExtendedTableCursors0511( ) ;
      }

      protected void Update0511( )
      {
         BeforeValidate0511( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0511( ) ;
         }
         if ( ( nIsMod_11 != 0 ) || ( nIsDirty_11 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0511( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0511( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0511( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000533 */
                        pr_default.execute(27, new Object[] {A34FlyghtSeatLocation, A20FlyghtId, A33FlyghtSeatId, A35FlyghtSeatChar});
                        pr_default.close(27);
                        pr_default.SmartCacheProvider.SetUpdated("FlyghtSeat");
                        if ( (pr_default.getStatus(27) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"FlyghtSeat"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0511( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0511( ) ;
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
               EndLevel0511( ) ;
            }
         }
         CloseExtendedTableCursors0511( ) ;
      }

      protected void DeferredUpdate0511( )
      {
      }

      protected void Delete0511( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0511( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0511( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0511( ) ;
            AfterConfirm0511( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0511( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000534 */
                  pr_default.execute(28, new Object[] {A20FlyghtId, A33FlyghtSeatId, A35FlyghtSeatChar});
                  pr_default.close(28);
                  pr_default.SmartCacheProvider.SetUpdated("FlyghtSeat");
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
         sMode11 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0511( ) ;
         Gx_mode = sMode11;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0511( )
      {
         standaloneModal0511( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            if ( IsIns( )  )
            {
               A36FlyghtCapacity = (short)(O36FlyghtCapacity+1);
               n36FlyghtCapacity = false;
               AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
            }
            else
            {
               if ( IsUpd( )  )
               {
                  A36FlyghtCapacity = O36FlyghtCapacity;
                  n36FlyghtCapacity = false;
                  AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
               }
               else
               {
                  if ( IsDlt( )  )
                  {
                     A36FlyghtCapacity = (short)(O36FlyghtCapacity-1);
                     n36FlyghtCapacity = false;
                     AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
                  }
               }
            }
         }
      }

      protected void EndLevel0511( )
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

      public void ScanStart0511( )
      {
         /* Scan By routine */
         /* Using cursor T000535 */
         pr_default.execute(29, new Object[] {A20FlyghtId});
         RcdFound11 = 0;
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound11 = 1;
            A33FlyghtSeatId = T000535_A33FlyghtSeatId[0];
            A35FlyghtSeatChar = T000535_A35FlyghtSeatChar[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0511( )
      {
         /* Scan next routine */
         pr_default.readNext(29);
         RcdFound11 = 0;
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound11 = 1;
            A33FlyghtSeatId = T000535_A33FlyghtSeatId[0];
            A35FlyghtSeatChar = T000535_A35FlyghtSeatChar[0];
         }
      }

      protected void ScanEnd0511( )
      {
         pr_default.close(29);
      }

      protected void AfterConfirm0511( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0511( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0511( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0511( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0511( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0511( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0511( )
      {
         edtFlyghtSeatId_Enabled = 0;
         AssignProp("", false, edtFlyghtSeatId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlyghtSeatId_Enabled), 5, 0), !bGXsfl_98_Refreshing);
         cmbFlyghtSeatChar.Enabled = 0;
         AssignProp("", false, cmbFlyghtSeatChar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbFlyghtSeatChar.Enabled), 5, 0), !bGXsfl_98_Refreshing);
         cmbFlyghtSeatLocation.Enabled = 0;
         AssignProp("", false, cmbFlyghtSeatLocation_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbFlyghtSeatLocation.Enabled), 5, 0), !bGXsfl_98_Refreshing);
      }

      protected void send_integrity_lvl_hashes0511( )
      {
      }

      protected void send_integrity_lvl_hashes058( )
      {
      }

      protected void SubsflControlProps_9811( )
      {
         edtFlyghtSeatId_Internalname = "FLYGHTSEATID_"+sGXsfl_98_idx;
         cmbFlyghtSeatChar_Internalname = "FLYGHTSEATCHAR_"+sGXsfl_98_idx;
         cmbFlyghtSeatLocation_Internalname = "FLYGHTSEATLOCATION_"+sGXsfl_98_idx;
      }

      protected void SubsflControlProps_fel_9811( )
      {
         edtFlyghtSeatId_Internalname = "FLYGHTSEATID_"+sGXsfl_98_fel_idx;
         cmbFlyghtSeatChar_Internalname = "FLYGHTSEATCHAR_"+sGXsfl_98_fel_idx;
         cmbFlyghtSeatLocation_Internalname = "FLYGHTSEATLOCATION_"+sGXsfl_98_fel_idx;
      }

      protected void AddRow0511( )
      {
         nGXsfl_98_idx = (int)(nGXsfl_98_idx+1);
         sGXsfl_98_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_98_idx), 4, 0), 4, "0");
         SubsflControlProps_9811( ) ;
         SendRow0511( ) ;
      }

      protected void SendRow0511( )
      {
         Gridflyght_seatRow = GXWebRow.GetNew(context);
         if ( subGridflyght_seat_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridflyght_seat_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridflyght_seat_Class, "") != 0 )
            {
               subGridflyght_seat_Linesclass = subGridflyght_seat_Class+"Odd";
            }
         }
         else if ( subGridflyght_seat_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridflyght_seat_Backstyle = 0;
            subGridflyght_seat_Backcolor = subGridflyght_seat_Allbackcolor;
            if ( StringUtil.StrCmp(subGridflyght_seat_Class, "") != 0 )
            {
               subGridflyght_seat_Linesclass = subGridflyght_seat_Class+"Uniform";
            }
         }
         else if ( subGridflyght_seat_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridflyght_seat_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridflyght_seat_Class, "") != 0 )
            {
               subGridflyght_seat_Linesclass = subGridflyght_seat_Class+"Odd";
            }
            subGridflyght_seat_Backcolor = (int)(0x0);
         }
         else if ( subGridflyght_seat_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridflyght_seat_Backstyle = 1;
            if ( ((int)((nGXsfl_98_idx) % (2))) == 0 )
            {
               subGridflyght_seat_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridflyght_seat_Class, "") != 0 )
               {
                  subGridflyght_seat_Linesclass = subGridflyght_seat_Class+"Even";
               }
            }
            else
            {
               subGridflyght_seat_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridflyght_seat_Class, "") != 0 )
               {
                  subGridflyght_seat_Linesclass = subGridflyght_seat_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_11_" + sGXsfl_98_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 99,'',false,'" + sGXsfl_98_idx + "',98)\"";
         ROClassString = "Attribute";
         Gridflyght_seatRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFlyghtSeatId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A33FlyghtSeatId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A33FlyghtSeatId), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,99);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFlyghtSeatId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtFlyghtSeatId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)98,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_11_" + sGXsfl_98_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 100,'',false,'" + sGXsfl_98_idx + "',98)\"";
         GXCCtl = "FLYGHTSEATCHAR_" + sGXsfl_98_idx;
         cmbFlyghtSeatChar.Name = GXCCtl;
         cmbFlyghtSeatChar.WebTags = "";
         cmbFlyghtSeatChar.addItem("A", "A", 0);
         cmbFlyghtSeatChar.addItem("B", "B", 0);
         cmbFlyghtSeatChar.addItem("C", "C", 0);
         cmbFlyghtSeatChar.addItem("D", "D", 0);
         cmbFlyghtSeatChar.addItem("E", "E", 0);
         cmbFlyghtSeatChar.addItem("F", "F", 0);
         if ( cmbFlyghtSeatChar.ItemCount > 0 )
         {
            A35FlyghtSeatChar = cmbFlyghtSeatChar.getValidValue(A35FlyghtSeatChar);
         }
         /* ComboBox */
         Gridflyght_seatRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbFlyghtSeatChar,(string)cmbFlyghtSeatChar_Internalname,StringUtil.RTrim( A35FlyghtSeatChar),(short)1,(string)cmbFlyghtSeatChar_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbFlyghtSeatChar.Enabled,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,100);\"",(string)"",(bool)true,(short)0});
         cmbFlyghtSeatChar.CurrentValue = StringUtil.RTrim( A35FlyghtSeatChar);
         AssignProp("", false, cmbFlyghtSeatChar_Internalname, "Values", (string)(cmbFlyghtSeatChar.ToJavascriptSource()), !bGXsfl_98_Refreshing);
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_11_" + sGXsfl_98_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 101,'',false,'" + sGXsfl_98_idx + "',98)\"";
         if ( ( cmbFlyghtSeatLocation.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "FLYGHTSEATLOCATION_" + sGXsfl_98_idx;
            cmbFlyghtSeatLocation.Name = GXCCtl;
            cmbFlyghtSeatLocation.WebTags = "";
            cmbFlyghtSeatLocation.addItem("W", "Window", 0);
            cmbFlyghtSeatLocation.addItem("M", "Midle", 0);
            cmbFlyghtSeatLocation.addItem("A", "Aisle", 0);
            if ( cmbFlyghtSeatLocation.ItemCount > 0 )
            {
               A34FlyghtSeatLocation = cmbFlyghtSeatLocation.getValidValue(A34FlyghtSeatLocation);
            }
         }
         /* ComboBox */
         Gridflyght_seatRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbFlyghtSeatLocation,(string)cmbFlyghtSeatLocation_Internalname,StringUtil.RTrim( A34FlyghtSeatLocation),(short)1,(string)cmbFlyghtSeatLocation_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbFlyghtSeatLocation.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"",(string)"",(bool)true,(short)0});
         cmbFlyghtSeatLocation.CurrentValue = StringUtil.RTrim( A34FlyghtSeatLocation);
         AssignProp("", false, cmbFlyghtSeatLocation_Internalname, "Values", (string)(cmbFlyghtSeatLocation.ToJavascriptSource()), !bGXsfl_98_Refreshing);
         ajax_sending_grid_row(Gridflyght_seatRow);
         send_integrity_lvl_hashes0511( ) ;
         GXCCtl = "Z33FlyghtSeatId_" + sGXsfl_98_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z33FlyghtSeatId), 4, 0, ".", "")));
         GXCCtl = "Z35FlyghtSeatChar_" + sGXsfl_98_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z35FlyghtSeatChar));
         GXCCtl = "Z34FlyghtSeatLocation_" + sGXsfl_98_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z34FlyghtSeatLocation));
         GXCCtl = "nRcdDeleted_11_" + sGXsfl_98_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_11), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_11_" + sGXsfl_98_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_11), 4, 0, ".", "")));
         GXCCtl = "nIsMod_11_" + sGXsfl_98_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_11), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FLYGHTSEATID_"+sGXsfl_98_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtFlyghtSeatId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FLYGHTSEATCHAR_"+sGXsfl_98_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbFlyghtSeatChar.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FLYGHTSEATLOCATION_"+sGXsfl_98_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbFlyghtSeatLocation.Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridflyght_seatContainer.AddRow(Gridflyght_seatRow);
      }

      protected void ReadRow0511( )
      {
         nGXsfl_98_idx = (int)(nGXsfl_98_idx+1);
         sGXsfl_98_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_98_idx), 4, 0), 4, "0");
         SubsflControlProps_9811( ) ;
         edtFlyghtSeatId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "FLYGHTSEATID_"+sGXsfl_98_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         cmbFlyghtSeatChar.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "FLYGHTSEATCHAR_"+sGXsfl_98_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         cmbFlyghtSeatLocation.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "FLYGHTSEATLOCATION_"+sGXsfl_98_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtFlyghtSeatId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFlyghtSeatId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "FLYGHTSEATID_" + sGXsfl_98_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtFlyghtSeatId_Internalname;
            wbErr = true;
            A33FlyghtSeatId = 0;
         }
         else
         {
            A33FlyghtSeatId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtFlyghtSeatId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
         }
         cmbFlyghtSeatChar.Name = cmbFlyghtSeatChar_Internalname;
         cmbFlyghtSeatChar.CurrentValue = cgiGet( cmbFlyghtSeatChar_Internalname);
         A35FlyghtSeatChar = cgiGet( cmbFlyghtSeatChar_Internalname);
         cmbFlyghtSeatLocation.Name = cmbFlyghtSeatLocation_Internalname;
         cmbFlyghtSeatLocation.CurrentValue = cgiGet( cmbFlyghtSeatLocation_Internalname);
         A34FlyghtSeatLocation = cgiGet( cmbFlyghtSeatLocation_Internalname);
         GXCCtl = "Z33FlyghtSeatId_" + sGXsfl_98_idx;
         Z33FlyghtSeatId = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "Z35FlyghtSeatChar_" + sGXsfl_98_idx;
         Z35FlyghtSeatChar = cgiGet( GXCCtl);
         GXCCtl = "Z34FlyghtSeatLocation_" + sGXsfl_98_idx;
         Z34FlyghtSeatLocation = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_11_" + sGXsfl_98_idx;
         nRcdDeleted_11 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_11_" + sGXsfl_98_idx;
         nRcdExists_11 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_11_" + sGXsfl_98_idx;
         nIsMod_11 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defcmbFlyghtSeatChar_Enabled = cmbFlyghtSeatChar.Enabled;
         defedtFlyghtSeatId_Enabled = edtFlyghtSeatId_Enabled;
      }

      protected void ConfirmValues050( )
      {
         nGXsfl_98_idx = 0;
         sGXsfl_98_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_98_idx), 4, 0), 4, "0");
         SubsflControlProps_9811( ) ;
         while ( nGXsfl_98_idx < nRC_GXsfl_98 )
         {
            nGXsfl_98_idx = (int)(nGXsfl_98_idx+1);
            sGXsfl_98_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_98_idx), 4, 0), 4, "0");
            SubsflControlProps_9811( ) ;
            ChangePostValue( "Z33FlyghtSeatId_"+sGXsfl_98_idx, cgiGet( "ZT_"+"Z33FlyghtSeatId_"+sGXsfl_98_idx)) ;
            DeletePostValue( "ZT_"+"Z33FlyghtSeatId_"+sGXsfl_98_idx) ;
            ChangePostValue( "Z35FlyghtSeatChar_"+sGXsfl_98_idx, cgiGet( "ZT_"+"Z35FlyghtSeatChar_"+sGXsfl_98_idx)) ;
            DeletePostValue( "ZT_"+"Z35FlyghtSeatChar_"+sGXsfl_98_idx) ;
            ChangePostValue( "Z34FlyghtSeatLocation_"+sGXsfl_98_idx, cgiGet( "ZT_"+"Z34FlyghtSeatLocation_"+sGXsfl_98_idx)) ;
            DeletePostValue( "ZT_"+"Z34FlyghtSeatLocation_"+sGXsfl_98_idx) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("flyght.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z20FlyghtId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z20FlyghtId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z27FlyghtPrice", StringUtil.LTrim( StringUtil.NToC( Z27FlyghtPrice, 9, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z28FlyghtPricePercentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z28FlyghtPricePercentage), 3, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z30AirlineID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z30AirlineID), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z22FlyghtDepartureAirportId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z22FlyghtDepartureAirportId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z25FlyghtArrivalAirportId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z25FlyghtArrivalAirportId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "O36FlyghtCapacity", StringUtil.LTrim( StringUtil.NToC( (decimal)(O36FlyghtCapacity), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_98", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_98_idx), 8, 0, ".", "")));
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
         return formatLink("flyght.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Flyght" ;
      }

      public override string GetPgmdesc( )
      {
         return "Flyght" ;
      }

      protected void InitializeNonKey058( )
      {
         A29FlyghtFinalPrice = 0;
         AssignAttri("", false, "A29FlyghtFinalPrice", StringUtil.LTrimStr( A29FlyghtFinalPrice, 9, 2));
         A22FlyghtDepartureAirportId = 0;
         AssignAttri("", false, "A22FlyghtDepartureAirportId", StringUtil.LTrimStr( (decimal)(A22FlyghtDepartureAirportId), 4, 0));
         A23FlyghtDepartureAirportName = "";
         AssignAttri("", false, "A23FlyghtDepartureAirportName", A23FlyghtDepartureAirportName);
         A25FlyghtArrivalAirportId = 0;
         AssignAttri("", false, "A25FlyghtArrivalAirportId", StringUtil.LTrimStr( (decimal)(A25FlyghtArrivalAirportId), 4, 0));
         A26FlyghtArrivalAirportName = "";
         AssignAttri("", false, "A26FlyghtArrivalAirportName", A26FlyghtArrivalAirportName);
         A27FlyghtPrice = 0;
         AssignAttri("", false, "A27FlyghtPrice", StringUtil.LTrimStr( A27FlyghtPrice, 9, 2));
         A28FlyghtPricePercentage = 0;
         AssignAttri("", false, "A28FlyghtPricePercentage", StringUtil.LTrimStr( (decimal)(A28FlyghtPricePercentage), 3, 0));
         A30AirlineID = 0;
         n30AirlineID = false;
         AssignAttri("", false, "A30AirlineID", StringUtil.LTrimStr( (decimal)(A30AirlineID), 4, 0));
         n30AirlineID = ((0==A30AirlineID) ? true : false);
         A31AirlineName = "";
         AssignAttri("", false, "A31AirlineName", A31AirlineName);
         A32AirlineDiscountPercentage = 0;
         AssignAttri("", false, "A32AirlineDiscountPercentage", StringUtil.LTrimStr( (decimal)(A32AirlineDiscountPercentage), 3, 0));
         A36FlyghtCapacity = 0;
         n36FlyghtCapacity = false;
         AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
         O36FlyghtCapacity = A36FlyghtCapacity;
         n36FlyghtCapacity = false;
         AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrimStr( (decimal)(A36FlyghtCapacity), 4, 0));
         Z27FlyghtPrice = 0;
         Z28FlyghtPricePercentage = 0;
         Z30AirlineID = 0;
         Z22FlyghtDepartureAirportId = 0;
         Z25FlyghtArrivalAirportId = 0;
      }

      protected void InitAll058( )
      {
         A20FlyghtId = 0;
         AssignAttri("", false, "A20FlyghtId", StringUtil.LTrimStr( (decimal)(A20FlyghtId), 4, 0));
         InitializeNonKey058( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0511( )
      {
         A34FlyghtSeatLocation = "";
         Z34FlyghtSeatLocation = "";
      }

      protected void InitAll0511( )
      {
         A33FlyghtSeatId = 0;
         A35FlyghtSeatChar = "";
         InitializeNonKey0511( ) ;
      }

      protected void StandaloneModalInsert0511( )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20245308572377", true, true);
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
         context.AddJavascriptSource("flyght.js", "?20245308572378", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties11( )
      {
         cmbFlyghtSeatChar.Enabled = defcmbFlyghtSeatChar_Enabled;
         AssignProp("", false, cmbFlyghtSeatChar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbFlyghtSeatChar.Enabled), 5, 0), !bGXsfl_98_Refreshing);
         edtFlyghtSeatId_Enabled = defedtFlyghtSeatId_Enabled;
         AssignProp("", false, edtFlyghtSeatId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlyghtSeatId_Enabled), 5, 0), !bGXsfl_98_Refreshing);
      }

      protected void StartGridControl98( )
      {
         Gridflyght_seatContainer.AddObjectProperty("GridName", "Gridflyght_seat");
         Gridflyght_seatContainer.AddObjectProperty("Header", subGridflyght_seat_Header);
         Gridflyght_seatContainer.AddObjectProperty("Class", "Grid");
         Gridflyght_seatContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridflyght_seatContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridflyght_seatContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridflyght_seat_Backcolorstyle), 1, 0, ".", "")));
         Gridflyght_seatContainer.AddObjectProperty("CmpContext", "");
         Gridflyght_seatContainer.AddObjectProperty("InMasterPage", "false");
         Gridflyght_seatColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridflyght_seatColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A33FlyghtSeatId), 4, 0, ".", ""))));
         Gridflyght_seatColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtFlyghtSeatId_Enabled), 5, 0, ".", "")));
         Gridflyght_seatContainer.AddColumnProperties(Gridflyght_seatColumn);
         Gridflyght_seatColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridflyght_seatColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A35FlyghtSeatChar)));
         Gridflyght_seatColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbFlyghtSeatChar.Enabled), 5, 0, ".", "")));
         Gridflyght_seatContainer.AddColumnProperties(Gridflyght_seatColumn);
         Gridflyght_seatColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridflyght_seatColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A34FlyghtSeatLocation)));
         Gridflyght_seatColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbFlyghtSeatLocation.Enabled), 5, 0, ".", "")));
         Gridflyght_seatContainer.AddColumnProperties(Gridflyght_seatColumn);
         Gridflyght_seatContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridflyght_seat_Selectedindex), 4, 0, ".", "")));
         Gridflyght_seatContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridflyght_seat_Allowselection), 1, 0, ".", "")));
         Gridflyght_seatContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridflyght_seat_Selectioncolor), 9, 0, ".", "")));
         Gridflyght_seatContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridflyght_seat_Allowhovering), 1, 0, ".", "")));
         Gridflyght_seatContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridflyght_seat_Hoveringcolor), 9, 0, ".", "")));
         Gridflyght_seatContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridflyght_seat_Allowcollapsing), 1, 0, ".", "")));
         Gridflyght_seatContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridflyght_seat_Collapsed), 1, 0, ".", "")));
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
         edtFlyghtId_Internalname = "FLYGHTID";
         edtFlyghtDepartureAirportId_Internalname = "FLYGHTDEPARTUREAIRPORTID";
         edtFlyghtDepartureAirportName_Internalname = "FLYGHTDEPARTUREAIRPORTNAME";
         edtFlyghtArrivalAirportId_Internalname = "FLYGHTARRIVALAIRPORTID";
         edtFlyghtArrivalAirportName_Internalname = "FLYGHTARRIVALAIRPORTNAME";
         edtFlyghtPrice_Internalname = "FLYGHTPRICE";
         edtFlyghtPricePercentage_Internalname = "FLYGHTPRICEPERCENTAGE";
         edtAirlineID_Internalname = "AIRLINEID";
         edtAirlineName_Internalname = "AIRLINENAME";
         edtAirlineDiscountPercentage_Internalname = "AIRLINEDISCOUNTPERCENTAGE";
         edtFlyghtFinalPrice_Internalname = "FLYGHTFINALPRICE";
         edtFlyghtCapacity_Internalname = "FLYGHTCAPACITY";
         lblTitleseat_Internalname = "TITLESEAT";
         edtFlyghtSeatId_Internalname = "FLYGHTSEATID";
         cmbFlyghtSeatChar_Internalname = "FLYGHTSEATCHAR";
         cmbFlyghtSeatLocation_Internalname = "FLYGHTSEATLOCATION";
         divSeattable_Internalname = "SEATTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_22_Internalname = "PROMPT_22";
         imgprompt_25_Internalname = "PROMPT_25";
         imgprompt_30_Internalname = "PROMPT_30";
         subGridflyght_seat_Internalname = "GRIDFLYGHT_SEAT";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("TravelAgency", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridflyght_seat_Allowcollapsing = 0;
         subGridflyght_seat_Allowselection = 0;
         subGridflyght_seat_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Flyght";
         cmbFlyghtSeatLocation_Jsonclick = "";
         cmbFlyghtSeatChar_Jsonclick = "";
         edtFlyghtSeatId_Jsonclick = "";
         subGridflyght_seat_Class = "Grid";
         subGridflyght_seat_Backcolorstyle = 0;
         cmbFlyghtSeatLocation.Enabled = 1;
         cmbFlyghtSeatChar.Enabled = 1;
         edtFlyghtSeatId_Enabled = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtFlyghtCapacity_Jsonclick = "";
         edtFlyghtCapacity_Enabled = 0;
         edtFlyghtFinalPrice_Jsonclick = "";
         edtFlyghtFinalPrice_Enabled = 0;
         edtAirlineDiscountPercentage_Jsonclick = "";
         edtAirlineDiscountPercentage_Enabled = 0;
         edtAirlineName_Jsonclick = "";
         edtAirlineName_Enabled = 0;
         imgprompt_30_Visible = 1;
         imgprompt_30_Link = "";
         edtAirlineID_Jsonclick = "";
         edtAirlineID_Enabled = 1;
         edtFlyghtPricePercentage_Jsonclick = "";
         edtFlyghtPricePercentage_Enabled = 1;
         edtFlyghtPrice_Jsonclick = "";
         edtFlyghtPrice_Enabled = 1;
         edtFlyghtArrivalAirportName_Jsonclick = "";
         edtFlyghtArrivalAirportName_Enabled = 0;
         imgprompt_25_Visible = 1;
         imgprompt_25_Link = "";
         edtFlyghtArrivalAirportId_Jsonclick = "";
         edtFlyghtArrivalAirportId_Enabled = 1;
         edtFlyghtDepartureAirportName_Jsonclick = "";
         edtFlyghtDepartureAirportName_Enabled = 0;
         imgprompt_22_Visible = 1;
         imgprompt_22_Link = "";
         edtFlyghtDepartureAirportId_Jsonclick = "";
         edtFlyghtDepartureAirportId_Enabled = 1;
         edtFlyghtId_Jsonclick = "";
         edtFlyghtId_Enabled = 1;
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

      protected void gxnrGridflyght_seat_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_9811( ) ;
         while ( nGXsfl_98_idx <= nRC_GXsfl_98 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0511( ) ;
            standaloneModal0511( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0511( ) ;
            nGXsfl_98_idx = (int)(nGXsfl_98_idx+1);
            sGXsfl_98_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_98_idx), 4, 0), 4, "0");
            SubsflControlProps_9811( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridflyght_seatContainer)) ;
         /* End function gxnrGridflyght_seat_newrow */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "FLYGHTSEATCHAR_" + sGXsfl_98_idx;
         cmbFlyghtSeatChar.Name = GXCCtl;
         cmbFlyghtSeatChar.WebTags = "";
         cmbFlyghtSeatChar.addItem("A", "A", 0);
         cmbFlyghtSeatChar.addItem("B", "B", 0);
         cmbFlyghtSeatChar.addItem("C", "C", 0);
         cmbFlyghtSeatChar.addItem("D", "D", 0);
         cmbFlyghtSeatChar.addItem("E", "E", 0);
         cmbFlyghtSeatChar.addItem("F", "F", 0);
         if ( cmbFlyghtSeatChar.ItemCount > 0 )
         {
            A35FlyghtSeatChar = cmbFlyghtSeatChar.getValidValue(A35FlyghtSeatChar);
         }
         GXCCtl = "FLYGHTSEATLOCATION_" + sGXsfl_98_idx;
         cmbFlyghtSeatLocation.Name = GXCCtl;
         cmbFlyghtSeatLocation.WebTags = "";
         cmbFlyghtSeatLocation.addItem("W", "Window", 0);
         cmbFlyghtSeatLocation.addItem("M", "Midle", 0);
         cmbFlyghtSeatLocation.addItem("A", "Aisle", 0);
         if ( cmbFlyghtSeatLocation.ItemCount > 0 )
         {
            A34FlyghtSeatLocation = cmbFlyghtSeatLocation.getValidValue(A34FlyghtSeatLocation);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtFlyghtDepartureAirportId_Internalname;
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

      public void Valid_Flyghtid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T000525 */
         pr_default.execute(19, new Object[] {A20FlyghtId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            A36FlyghtCapacity = T000525_A36FlyghtCapacity[0];
            n36FlyghtCapacity = T000525_n36FlyghtCapacity[0];
         }
         else
         {
            A36FlyghtCapacity = 0;
            n36FlyghtCapacity = false;
         }
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A22FlyghtDepartureAirportId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A22FlyghtDepartureAirportId), 4, 0, ".", "")));
         AssignAttri("", false, "A25FlyghtArrivalAirportId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A25FlyghtArrivalAirportId), 4, 0, ".", "")));
         AssignAttri("", false, "A27FlyghtPrice", StringUtil.LTrim( StringUtil.NToC( A27FlyghtPrice, 9, 2, ".", "")));
         AssignAttri("", false, "A28FlyghtPricePercentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(A28FlyghtPricePercentage), 3, 0, ".", "")));
         AssignAttri("", false, "A30AirlineID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A30AirlineID), 4, 0, ".", "")));
         AssignAttri("", false, "A36FlyghtCapacity", StringUtil.LTrim( StringUtil.NToC( (decimal)(A36FlyghtCapacity), 4, 0, ".", "")));
         AssignAttri("", false, "A23FlyghtDepartureAirportName", StringUtil.RTrim( A23FlyghtDepartureAirportName));
         AssignAttri("", false, "A26FlyghtArrivalAirportName", StringUtil.RTrim( A26FlyghtArrivalAirportName));
         AssignAttri("", false, "A31AirlineName", StringUtil.RTrim( A31AirlineName));
         AssignAttri("", false, "A32AirlineDiscountPercentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(A32AirlineDiscountPercentage), 3, 0, ".", "")));
         AssignAttri("", false, "A29FlyghtFinalPrice", StringUtil.LTrim( StringUtil.NToC( A29FlyghtFinalPrice, 9, 2, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z20FlyghtId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z20FlyghtId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z22FlyghtDepartureAirportId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z22FlyghtDepartureAirportId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z25FlyghtArrivalAirportId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z25FlyghtArrivalAirportId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z27FlyghtPrice", StringUtil.LTrim( StringUtil.NToC( Z27FlyghtPrice, 9, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z28FlyghtPricePercentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z28FlyghtPricePercentage), 3, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z30AirlineID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z30AirlineID), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z36FlyghtCapacity", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z36FlyghtCapacity), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z23FlyghtDepartureAirportName", StringUtil.RTrim( Z23FlyghtDepartureAirportName));
         GxWebStd.gx_hidden_field( context, "Z26FlyghtArrivalAirportName", StringUtil.RTrim( Z26FlyghtArrivalAirportName));
         GxWebStd.gx_hidden_field( context, "Z31AirlineName", StringUtil.RTrim( Z31AirlineName));
         GxWebStd.gx_hidden_field( context, "Z32AirlineDiscountPercentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z32AirlineDiscountPercentage), 3, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z29FlyghtFinalPrice", StringUtil.LTrim( StringUtil.NToC( Z29FlyghtFinalPrice, 9, 2, ".", "")));
         AssignAttri("", false, "O36FlyghtCapacity", StringUtil.LTrim( StringUtil.NToC( (decimal)(O36FlyghtCapacity), 4, 0, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Flyghtdepartureairportid( )
      {
         /* Using cursor T000526 */
         pr_default.execute(20, new Object[] {A22FlyghtDepartureAirportId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No matching 'Flyght Departure Airport'.", "ForeignKeyNotFound", 1, "FLYGHTDEPARTUREAIRPORTID");
            AnyError = 1;
            GX_FocusControl = edtFlyghtDepartureAirportId_Internalname;
         }
         A23FlyghtDepartureAirportName = T000526_A23FlyghtDepartureAirportName[0];
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A23FlyghtDepartureAirportName", StringUtil.RTrim( A23FlyghtDepartureAirportName));
      }

      public void Valid_Flyghtarrivalairportid( )
      {
         /* Using cursor T000527 */
         pr_default.execute(21, new Object[] {A25FlyghtArrivalAirportId});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No matching 'Flyght Arrival Airport'.", "ForeignKeyNotFound", 1, "FLYGHTARRIVALAIRPORTID");
            AnyError = 1;
            GX_FocusControl = edtFlyghtArrivalAirportId_Internalname;
         }
         A26FlyghtArrivalAirportName = T000527_A26FlyghtArrivalAirportName[0];
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A26FlyghtArrivalAirportName", StringUtil.RTrim( A26FlyghtArrivalAirportName));
      }

      public void Valid_Airlineid( )
      {
         n30AirlineID = false;
         /* Using cursor T000528 */
         pr_default.execute(22, new Object[] {n30AirlineID, A30AirlineID});
         if ( (pr_default.getStatus(22) == 101) )
         {
            if ( ! ( (0==A30AirlineID) ) )
            {
               GX_msglist.addItem("No matching 'Airline'.", "ForeignKeyNotFound", 1, "AIRLINEID");
               AnyError = 1;
               GX_FocusControl = edtAirlineID_Internalname;
            }
         }
         A31AirlineName = T000528_A31AirlineName[0];
         A32AirlineDiscountPercentage = T000528_A32AirlineDiscountPercentage[0];
         pr_default.close(22);
         if ( A32AirlineDiscountPercentage > A28FlyghtPricePercentage )
         {
            A29FlyghtFinalPrice = (decimal)(A27FlyghtPrice*(1-A32AirlineDiscountPercentage/ (decimal)(100)));
         }
         else
         {
            if ( A32AirlineDiscountPercentage < A28FlyghtPricePercentage )
            {
               A29FlyghtFinalPrice = (decimal)(A27FlyghtPrice*(1-A28FlyghtPricePercentage/ (decimal)(100)));
            }
            else
            {
               A29FlyghtFinalPrice = 0;
            }
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A31AirlineName", StringUtil.RTrim( A31AirlineName));
         AssignAttri("", false, "A32AirlineDiscountPercentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(A32AirlineDiscountPercentage), 3, 0, ".", "")));
         AssignAttri("", false, "A29FlyghtFinalPrice", StringUtil.LTrim( StringUtil.NToC( A29FlyghtFinalPrice, 9, 2, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("VALID_FLYGHTID","""{"handler":"Valid_Flyghtid","iparms":[{"av":"A20FlyghtId","fld":"FLYGHTID","pic":"ZZZ9"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"}]""");
         setEventMetadata("VALID_FLYGHTID",""","oparms":[{"av":"A22FlyghtDepartureAirportId","fld":"FLYGHTDEPARTUREAIRPORTID","pic":"ZZZ9"},{"av":"A25FlyghtArrivalAirportId","fld":"FLYGHTARRIVALAIRPORTID","pic":"ZZZ9"},{"av":"A27FlyghtPrice","fld":"FLYGHTPRICE","pic":"ZZZZZ9.99"},{"av":"A28FlyghtPricePercentage","fld":"FLYGHTPRICEPERCENTAGE","pic":"ZZ9"},{"av":"A30AirlineID","fld":"AIRLINEID","pic":"ZZZ9"},{"av":"A36FlyghtCapacity","fld":"FLYGHTCAPACITY","pic":"ZZZ9"},{"av":"A23FlyghtDepartureAirportName","fld":"FLYGHTDEPARTUREAIRPORTNAME"},{"av":"A26FlyghtArrivalAirportName","fld":"FLYGHTARRIVALAIRPORTNAME"},{"av":"A31AirlineName","fld":"AIRLINENAME"},{"av":"A32AirlineDiscountPercentage","fld":"AIRLINEDISCOUNTPERCENTAGE","pic":"ZZ9"},{"av":"A29FlyghtFinalPrice","fld":"FLYGHTFINALPRICE","pic":"ZZZZZ9.99"},{"av":"Gx_mode","fld":"vMODE","pic":"@!"},{"av":"Z20FlyghtId"},{"av":"Z22FlyghtDepartureAirportId"},{"av":"Z25FlyghtArrivalAirportId"},{"av":"Z27FlyghtPrice"},{"av":"Z28FlyghtPricePercentage"},{"av":"Z30AirlineID"},{"av":"Z36FlyghtCapacity"},{"av":"Z23FlyghtDepartureAirportName"},{"av":"Z26FlyghtArrivalAirportName"},{"av":"Z31AirlineName"},{"av":"Z32AirlineDiscountPercentage"},{"av":"Z29FlyghtFinalPrice"},{"av":"O36FlyghtCapacity"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_FLYGHTDEPARTUREAIRPORTID","""{"handler":"Valid_Flyghtdepartureairportid","iparms":[{"av":"A22FlyghtDepartureAirportId","fld":"FLYGHTDEPARTUREAIRPORTID","pic":"ZZZ9"},{"av":"A23FlyghtDepartureAirportName","fld":"FLYGHTDEPARTUREAIRPORTNAME"}]""");
         setEventMetadata("VALID_FLYGHTDEPARTUREAIRPORTID",""","oparms":[{"av":"A23FlyghtDepartureAirportName","fld":"FLYGHTDEPARTUREAIRPORTNAME"}]}""");
         setEventMetadata("VALID_FLYGHTARRIVALAIRPORTID","""{"handler":"Valid_Flyghtarrivalairportid","iparms":[{"av":"A25FlyghtArrivalAirportId","fld":"FLYGHTARRIVALAIRPORTID","pic":"ZZZ9"},{"av":"A26FlyghtArrivalAirportName","fld":"FLYGHTARRIVALAIRPORTNAME"}]""");
         setEventMetadata("VALID_FLYGHTARRIVALAIRPORTID",""","oparms":[{"av":"A26FlyghtArrivalAirportName","fld":"FLYGHTARRIVALAIRPORTNAME"}]}""");
         setEventMetadata("VALID_FLYGHTPRICE","""{"handler":"Valid_Flyghtprice","iparms":[]}""");
         setEventMetadata("VALID_FLYGHTPRICEPERCENTAGE","""{"handler":"Valid_Flyghtpricepercentage","iparms":[]}""");
         setEventMetadata("VALID_AIRLINEID","""{"handler":"Valid_Airlineid","iparms":[{"av":"A30AirlineID","fld":"AIRLINEID","pic":"ZZZ9"},{"av":"A27FlyghtPrice","fld":"FLYGHTPRICE","pic":"ZZZZZ9.99"},{"av":"A32AirlineDiscountPercentage","fld":"AIRLINEDISCOUNTPERCENTAGE","pic":"ZZ9"},{"av":"A28FlyghtPricePercentage","fld":"FLYGHTPRICEPERCENTAGE","pic":"ZZ9"},{"av":"A31AirlineName","fld":"AIRLINENAME"},{"av":"A29FlyghtFinalPrice","fld":"FLYGHTFINALPRICE","pic":"ZZZZZ9.99"}]""");
         setEventMetadata("VALID_AIRLINEID",""","oparms":[{"av":"A31AirlineName","fld":"AIRLINENAME"},{"av":"A32AirlineDiscountPercentage","fld":"AIRLINEDISCOUNTPERCENTAGE","pic":"ZZ9"},{"av":"A29FlyghtFinalPrice","fld":"FLYGHTFINALPRICE","pic":"ZZZZZ9.99"}]}""");
         setEventMetadata("VALID_AIRLINEDISCOUNTPERCENTAGE","""{"handler":"Valid_Airlinediscountpercentage","iparms":[]}""");
         setEventMetadata("VALID_FLYGHTCAPACITY","""{"handler":"Valid_Flyghtcapacity","iparms":[]}""");
         setEventMetadata("VALID_FLYGHTSEATID","""{"handler":"Valid_Flyghtseatid","iparms":[]}""");
         setEventMetadata("VALID_FLYGHTSEATCHAR","""{"handler":"Valid_Flyghtseatchar","iparms":[]}""");
         setEventMetadata("VALID_FLYGHTSEATLOCATION","""{"handler":"Valid_Flyghtseatlocation","iparms":[]}""");
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
         pr_default.close(3);
         pr_default.close(22);
         pr_default.close(20);
         pr_default.close(21);
         pr_default.close(19);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z35FlyghtSeatChar = "";
         Z34FlyghtSeatLocation = "";
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
         imgprompt_22_gximage = "";
         sImgUrl = "";
         A23FlyghtDepartureAirportName = "";
         imgprompt_25_gximage = "";
         A26FlyghtArrivalAirportName = "";
         imgprompt_30_gximage = "";
         A31AirlineName = "";
         lblTitleseat_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridflyght_seatContainer = new GXWebGrid( context);
         sMode11 = "";
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A35FlyghtSeatChar = "";
         A34FlyghtSeatLocation = "";
         Z23FlyghtDepartureAirportName = "";
         Z26FlyghtArrivalAirportName = "";
         Z31AirlineName = "";
         T000512_A20FlyghtId = new short[1] ;
         T000512_A23FlyghtDepartureAirportName = new string[] {""} ;
         T000512_A26FlyghtArrivalAirportName = new string[] {""} ;
         T000512_A27FlyghtPrice = new decimal[1] ;
         T000512_A28FlyghtPricePercentage = new short[1] ;
         T000512_A31AirlineName = new string[] {""} ;
         T000512_A32AirlineDiscountPercentage = new short[1] ;
         T000512_A30AirlineID = new short[1] ;
         T000512_n30AirlineID = new bool[] {false} ;
         T000512_A22FlyghtDepartureAirportId = new short[1] ;
         T000512_A25FlyghtArrivalAirportId = new short[1] ;
         T000512_A36FlyghtCapacity = new short[1] ;
         T000512_n36FlyghtCapacity = new bool[] {false} ;
         T000510_A36FlyghtCapacity = new short[1] ;
         T000510_n36FlyghtCapacity = new bool[] {false} ;
         T00057_A23FlyghtDepartureAirportName = new string[] {""} ;
         T00058_A26FlyghtArrivalAirportName = new string[] {""} ;
         T00056_A31AirlineName = new string[] {""} ;
         T00056_A32AirlineDiscountPercentage = new short[1] ;
         T000514_A36FlyghtCapacity = new short[1] ;
         T000514_n36FlyghtCapacity = new bool[] {false} ;
         T000515_A23FlyghtDepartureAirportName = new string[] {""} ;
         T000516_A26FlyghtArrivalAirportName = new string[] {""} ;
         T000517_A31AirlineName = new string[] {""} ;
         T000517_A32AirlineDiscountPercentage = new short[1] ;
         T000518_A20FlyghtId = new short[1] ;
         T00055_A20FlyghtId = new short[1] ;
         T00055_A27FlyghtPrice = new decimal[1] ;
         T00055_A28FlyghtPricePercentage = new short[1] ;
         T00055_A30AirlineID = new short[1] ;
         T00055_n30AirlineID = new bool[] {false} ;
         T00055_A22FlyghtDepartureAirportId = new short[1] ;
         T00055_A25FlyghtArrivalAirportId = new short[1] ;
         sMode8 = "";
         T000519_A20FlyghtId = new short[1] ;
         T000520_A20FlyghtId = new short[1] ;
         T00054_A20FlyghtId = new short[1] ;
         T00054_A27FlyghtPrice = new decimal[1] ;
         T00054_A28FlyghtPricePercentage = new short[1] ;
         T00054_A30AirlineID = new short[1] ;
         T00054_n30AirlineID = new bool[] {false} ;
         T00054_A22FlyghtDepartureAirportId = new short[1] ;
         T00054_A25FlyghtArrivalAirportId = new short[1] ;
         T000521_A20FlyghtId = new short[1] ;
         T000525_A36FlyghtCapacity = new short[1] ;
         T000525_n36FlyghtCapacity = new bool[] {false} ;
         T000526_A23FlyghtDepartureAirportName = new string[] {""} ;
         T000527_A26FlyghtArrivalAirportName = new string[] {""} ;
         T000528_A31AirlineName = new string[] {""} ;
         T000528_A32AirlineDiscountPercentage = new short[1] ;
         T000529_A20FlyghtId = new short[1] ;
         T000530_A20FlyghtId = new short[1] ;
         T000530_A33FlyghtSeatId = new short[1] ;
         T000530_A35FlyghtSeatChar = new string[] {""} ;
         T000530_A34FlyghtSeatLocation = new string[] {""} ;
         T000531_A20FlyghtId = new short[1] ;
         T000531_A33FlyghtSeatId = new short[1] ;
         T000531_A35FlyghtSeatChar = new string[] {""} ;
         T00053_A20FlyghtId = new short[1] ;
         T00053_A33FlyghtSeatId = new short[1] ;
         T00053_A35FlyghtSeatChar = new string[] {""} ;
         T00053_A34FlyghtSeatLocation = new string[] {""} ;
         T00052_A20FlyghtId = new short[1] ;
         T00052_A33FlyghtSeatId = new short[1] ;
         T00052_A35FlyghtSeatChar = new string[] {""} ;
         T00052_A34FlyghtSeatLocation = new string[] {""} ;
         T000535_A20FlyghtId = new short[1] ;
         T000535_A33FlyghtSeatId = new short[1] ;
         T000535_A35FlyghtSeatChar = new string[] {""} ;
         Gridflyght_seatRow = new GXWebRow();
         subGridflyght_seat_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gridflyght_seatColumn = new GXWebColumn();
         ZZ23FlyghtDepartureAirportName = "";
         ZZ26FlyghtArrivalAirportName = "";
         ZZ31AirlineName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.flyght__default(),
            new Object[][] {
                new Object[] {
               T00052_A20FlyghtId, T00052_A33FlyghtSeatId, T00052_A35FlyghtSeatChar, T00052_A34FlyghtSeatLocation
               }
               , new Object[] {
               T00053_A20FlyghtId, T00053_A33FlyghtSeatId, T00053_A35FlyghtSeatChar, T00053_A34FlyghtSeatLocation
               }
               , new Object[] {
               T00054_A20FlyghtId, T00054_A27FlyghtPrice, T00054_A28FlyghtPricePercentage, T00054_A30AirlineID, T00054_n30AirlineID, T00054_A22FlyghtDepartureAirportId, T00054_A25FlyghtArrivalAirportId
               }
               , new Object[] {
               T00055_A20FlyghtId, T00055_A27FlyghtPrice, T00055_A28FlyghtPricePercentage, T00055_A30AirlineID, T00055_n30AirlineID, T00055_A22FlyghtDepartureAirportId, T00055_A25FlyghtArrivalAirportId
               }
               , new Object[] {
               T00056_A31AirlineName, T00056_A32AirlineDiscountPercentage
               }
               , new Object[] {
               T00057_A23FlyghtDepartureAirportName
               }
               , new Object[] {
               T00058_A26FlyghtArrivalAirportName
               }
               , new Object[] {
               T000510_A36FlyghtCapacity, T000510_n36FlyghtCapacity
               }
               , new Object[] {
               T000512_A20FlyghtId, T000512_A23FlyghtDepartureAirportName, T000512_A26FlyghtArrivalAirportName, T000512_A27FlyghtPrice, T000512_A28FlyghtPricePercentage, T000512_A31AirlineName, T000512_A32AirlineDiscountPercentage, T000512_A30AirlineID, T000512_n30AirlineID, T000512_A22FlyghtDepartureAirportId,
               T000512_A25FlyghtArrivalAirportId, T000512_A36FlyghtCapacity, T000512_n36FlyghtCapacity
               }
               , new Object[] {
               T000514_A36FlyghtCapacity, T000514_n36FlyghtCapacity
               }
               , new Object[] {
               T000515_A23FlyghtDepartureAirportName
               }
               , new Object[] {
               T000516_A26FlyghtArrivalAirportName
               }
               , new Object[] {
               T000517_A31AirlineName, T000517_A32AirlineDiscountPercentage
               }
               , new Object[] {
               T000518_A20FlyghtId
               }
               , new Object[] {
               T000519_A20FlyghtId
               }
               , new Object[] {
               T000520_A20FlyghtId
               }
               , new Object[] {
               T000521_A20FlyghtId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000525_A36FlyghtCapacity, T000525_n36FlyghtCapacity
               }
               , new Object[] {
               T000526_A23FlyghtDepartureAirportName
               }
               , new Object[] {
               T000527_A26FlyghtArrivalAirportName
               }
               , new Object[] {
               T000528_A31AirlineName, T000528_A32AirlineDiscountPercentage
               }
               , new Object[] {
               T000529_A20FlyghtId
               }
               , new Object[] {
               T000530_A20FlyghtId, T000530_A33FlyghtSeatId, T000530_A35FlyghtSeatChar, T000530_A34FlyghtSeatLocation
               }
               , new Object[] {
               T000531_A20FlyghtId, T000531_A33FlyghtSeatId, T000531_A35FlyghtSeatChar
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000535_A20FlyghtId, T000535_A33FlyghtSeatId, T000535_A35FlyghtSeatChar
               }
            }
         );
      }

      private short Z20FlyghtId ;
      private short Z28FlyghtPricePercentage ;
      private short Z30AirlineID ;
      private short Z22FlyghtDepartureAirportId ;
      private short Z25FlyghtArrivalAirportId ;
      private short O36FlyghtCapacity ;
      private short Z33FlyghtSeatId ;
      private short nRcdDeleted_11 ;
      private short nRcdExists_11 ;
      private short nIsMod_11 ;
      private short GxWebError ;
      private short A20FlyghtId ;
      private short A22FlyghtDepartureAirportId ;
      private short A25FlyghtArrivalAirportId ;
      private short A30AirlineID ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A28FlyghtPricePercentage ;
      private short A32AirlineDiscountPercentage ;
      private short A36FlyghtCapacity ;
      private short nBlankRcdCount11 ;
      private short RcdFound11 ;
      private short B36FlyghtCapacity ;
      private short nBlankRcdUsr11 ;
      private short s36FlyghtCapacity ;
      private short A33FlyghtSeatId ;
      private short Z36FlyghtCapacity ;
      private short Z32AirlineDiscountPercentage ;
      private short RcdFound8 ;
      private short Gx_BScreen ;
      private short nIsDirty_11 ;
      private short subGridflyght_seat_Backcolorstyle ;
      private short subGridflyght_seat_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridflyght_seat_Allowselection ;
      private short subGridflyght_seat_Allowhovering ;
      private short subGridflyght_seat_Allowcollapsing ;
      private short subGridflyght_seat_Collapsed ;
      private short ZZ20FlyghtId ;
      private short ZZ22FlyghtDepartureAirportId ;
      private short ZZ25FlyghtArrivalAirportId ;
      private short ZZ28FlyghtPricePercentage ;
      private short ZZ30AirlineID ;
      private short ZZ36FlyghtCapacity ;
      private short ZZ32AirlineDiscountPercentage ;
      private short ZO36FlyghtCapacity ;
      private int nRC_GXsfl_98 ;
      private int nGXsfl_98_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtFlyghtId_Enabled ;
      private int edtFlyghtDepartureAirportId_Enabled ;
      private int imgprompt_22_Visible ;
      private int edtFlyghtDepartureAirportName_Enabled ;
      private int edtFlyghtArrivalAirportId_Enabled ;
      private int imgprompt_25_Visible ;
      private int edtFlyghtArrivalAirportName_Enabled ;
      private int edtFlyghtPrice_Enabled ;
      private int edtFlyghtPricePercentage_Enabled ;
      private int edtAirlineID_Enabled ;
      private int imgprompt_30_Visible ;
      private int edtAirlineName_Enabled ;
      private int edtAirlineDiscountPercentage_Enabled ;
      private int edtFlyghtFinalPrice_Enabled ;
      private int edtFlyghtCapacity_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtFlyghtSeatId_Enabled ;
      private int fRowAdded ;
      private int subGridflyght_seat_Backcolor ;
      private int subGridflyght_seat_Allbackcolor ;
      private int defcmbFlyghtSeatChar_Enabled ;
      private int defedtFlyghtSeatId_Enabled ;
      private int idxLst ;
      private int subGridflyght_seat_Selectedindex ;
      private int subGridflyght_seat_Selectioncolor ;
      private int subGridflyght_seat_Hoveringcolor ;
      private long GRIDFLYGHT_SEAT_nFirstRecordOnPage ;
      private decimal Z27FlyghtPrice ;
      private decimal A27FlyghtPrice ;
      private decimal A29FlyghtFinalPrice ;
      private decimal Z29FlyghtFinalPrice ;
      private decimal ZZ27FlyghtPrice ;
      private decimal ZZ29FlyghtFinalPrice ;
      private string sPrefix ;
      private string Z35FlyghtSeatChar ;
      private string Z34FlyghtSeatLocation ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtFlyghtId_Internalname ;
      private string sGXsfl_98_idx="0001" ;
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
      private string edtFlyghtId_Jsonclick ;
      private string edtFlyghtDepartureAirportId_Internalname ;
      private string edtFlyghtDepartureAirportId_Jsonclick ;
      private string imgprompt_22_gximage ;
      private string sImgUrl ;
      private string imgprompt_22_Internalname ;
      private string imgprompt_22_Link ;
      private string edtFlyghtDepartureAirportName_Internalname ;
      private string A23FlyghtDepartureAirportName ;
      private string edtFlyghtDepartureAirportName_Jsonclick ;
      private string edtFlyghtArrivalAirportId_Internalname ;
      private string edtFlyghtArrivalAirportId_Jsonclick ;
      private string imgprompt_25_gximage ;
      private string imgprompt_25_Internalname ;
      private string imgprompt_25_Link ;
      private string edtFlyghtArrivalAirportName_Internalname ;
      private string A26FlyghtArrivalAirportName ;
      private string edtFlyghtArrivalAirportName_Jsonclick ;
      private string edtFlyghtPrice_Internalname ;
      private string edtFlyghtPrice_Jsonclick ;
      private string edtFlyghtPricePercentage_Internalname ;
      private string edtFlyghtPricePercentage_Jsonclick ;
      private string edtAirlineID_Internalname ;
      private string edtAirlineID_Jsonclick ;
      private string imgprompt_30_gximage ;
      private string imgprompt_30_Internalname ;
      private string imgprompt_30_Link ;
      private string edtAirlineName_Internalname ;
      private string A31AirlineName ;
      private string edtAirlineName_Jsonclick ;
      private string edtAirlineDiscountPercentage_Internalname ;
      private string edtAirlineDiscountPercentage_Jsonclick ;
      private string edtFlyghtFinalPrice_Internalname ;
      private string edtFlyghtFinalPrice_Jsonclick ;
      private string edtFlyghtCapacity_Internalname ;
      private string edtFlyghtCapacity_Jsonclick ;
      private string divSeattable_Internalname ;
      private string lblTitleseat_Internalname ;
      private string lblTitleseat_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sMode11 ;
      private string edtFlyghtSeatId_Internalname ;
      private string cmbFlyghtSeatChar_Internalname ;
      private string cmbFlyghtSeatLocation_Internalname ;
      private string sStyleString ;
      private string subGridflyght_seat_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string A35FlyghtSeatChar ;
      private string A34FlyghtSeatLocation ;
      private string Z23FlyghtDepartureAirportName ;
      private string Z26FlyghtArrivalAirportName ;
      private string Z31AirlineName ;
      private string sMode8 ;
      private string sGXsfl_98_fel_idx="0001" ;
      private string subGridflyght_seat_Class ;
      private string subGridflyght_seat_Linesclass ;
      private string ROClassString ;
      private string edtFlyghtSeatId_Jsonclick ;
      private string cmbFlyghtSeatChar_Jsonclick ;
      private string cmbFlyghtSeatLocation_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridflyght_seat_Header ;
      private string ZZ23FlyghtDepartureAirportName ;
      private string ZZ26FlyghtArrivalAirportName ;
      private string ZZ31AirlineName ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n30AirlineID ;
      private bool wbErr ;
      private bool n36FlyghtCapacity ;
      private bool bGXsfl_98_Refreshing=false ;
      private GXWebGrid Gridflyght_seatContainer ;
      private GXWebRow Gridflyght_seatRow ;
      private GXWebColumn Gridflyght_seatColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbFlyghtSeatChar ;
      private GXCombobox cmbFlyghtSeatLocation ;
      private IDataStoreProvider pr_default ;
      private short[] T000512_A20FlyghtId ;
      private string[] T000512_A23FlyghtDepartureAirportName ;
      private string[] T000512_A26FlyghtArrivalAirportName ;
      private decimal[] T000512_A27FlyghtPrice ;
      private short[] T000512_A28FlyghtPricePercentage ;
      private string[] T000512_A31AirlineName ;
      private short[] T000512_A32AirlineDiscountPercentage ;
      private short[] T000512_A30AirlineID ;
      private bool[] T000512_n30AirlineID ;
      private short[] T000512_A22FlyghtDepartureAirportId ;
      private short[] T000512_A25FlyghtArrivalAirportId ;
      private short[] T000512_A36FlyghtCapacity ;
      private bool[] T000512_n36FlyghtCapacity ;
      private short[] T000510_A36FlyghtCapacity ;
      private bool[] T000510_n36FlyghtCapacity ;
      private string[] T00057_A23FlyghtDepartureAirportName ;
      private string[] T00058_A26FlyghtArrivalAirportName ;
      private string[] T00056_A31AirlineName ;
      private short[] T00056_A32AirlineDiscountPercentage ;
      private short[] T000514_A36FlyghtCapacity ;
      private bool[] T000514_n36FlyghtCapacity ;
      private string[] T000515_A23FlyghtDepartureAirportName ;
      private string[] T000516_A26FlyghtArrivalAirportName ;
      private string[] T000517_A31AirlineName ;
      private short[] T000517_A32AirlineDiscountPercentage ;
      private short[] T000518_A20FlyghtId ;
      private short[] T00055_A20FlyghtId ;
      private decimal[] T00055_A27FlyghtPrice ;
      private short[] T00055_A28FlyghtPricePercentage ;
      private short[] T00055_A30AirlineID ;
      private bool[] T00055_n30AirlineID ;
      private short[] T00055_A22FlyghtDepartureAirportId ;
      private short[] T00055_A25FlyghtArrivalAirportId ;
      private short[] T000519_A20FlyghtId ;
      private short[] T000520_A20FlyghtId ;
      private short[] T00054_A20FlyghtId ;
      private decimal[] T00054_A27FlyghtPrice ;
      private short[] T00054_A28FlyghtPricePercentage ;
      private short[] T00054_A30AirlineID ;
      private bool[] T00054_n30AirlineID ;
      private short[] T00054_A22FlyghtDepartureAirportId ;
      private short[] T00054_A25FlyghtArrivalAirportId ;
      private short[] T000521_A20FlyghtId ;
      private short[] T000525_A36FlyghtCapacity ;
      private bool[] T000525_n36FlyghtCapacity ;
      private string[] T000526_A23FlyghtDepartureAirportName ;
      private string[] T000527_A26FlyghtArrivalAirportName ;
      private string[] T000528_A31AirlineName ;
      private short[] T000528_A32AirlineDiscountPercentage ;
      private short[] T000529_A20FlyghtId ;
      private short[] T000530_A20FlyghtId ;
      private short[] T000530_A33FlyghtSeatId ;
      private string[] T000530_A35FlyghtSeatChar ;
      private string[] T000530_A34FlyghtSeatLocation ;
      private short[] T000531_A20FlyghtId ;
      private short[] T000531_A33FlyghtSeatId ;
      private string[] T000531_A35FlyghtSeatChar ;
      private short[] T00053_A20FlyghtId ;
      private short[] T00053_A33FlyghtSeatId ;
      private string[] T00053_A35FlyghtSeatChar ;
      private string[] T00053_A34FlyghtSeatLocation ;
      private short[] T00052_A20FlyghtId ;
      private short[] T00052_A33FlyghtSeatId ;
      private string[] T00052_A35FlyghtSeatChar ;
      private string[] T00052_A34FlyghtSeatLocation ;
      private short[] T000535_A20FlyghtId ;
      private short[] T000535_A33FlyghtSeatId ;
      private string[] T000535_A35FlyghtSeatChar ;
   }

   public class flyght__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new UpdateCursor(def[17])
         ,new UpdateCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new UpdateCursor(def[26])
         ,new UpdateCursor(def[27])
         ,new UpdateCursor(def[28])
         ,new ForEachCursor(def[29])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00052;
          prmT00052 = new Object[] {
          new ParDef("@FlyghtId",GXType.Int16,4,0) ,
          new ParDef("@FlyghtSeatId",GXType.Int16,4,0) ,
          new ParDef("@FlyghtSeatChar",GXType.NChar,1,0)
          };
          Object[] prmT00053;
          prmT00053 = new Object[] {
          new ParDef("@FlyghtId",GXType.Int16,4,0) ,
          new ParDef("@FlyghtSeatId",GXType.Int16,4,0) ,
          new ParDef("@FlyghtSeatChar",GXType.NChar,1,0)
          };
          Object[] prmT00054;
          prmT00054 = new Object[] {
          new ParDef("@FlyghtId",GXType.Int16,4,0)
          };
          Object[] prmT00055;
          prmT00055 = new Object[] {
          new ParDef("@FlyghtId",GXType.Int16,4,0)
          };
          Object[] prmT00056;
          prmT00056 = new Object[] {
          new ParDef("@AirlineID",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00057;
          prmT00057 = new Object[] {
          new ParDef("@FlyghtDepartureAirportId",GXType.Int16,4,0)
          };
          Object[] prmT00058;
          prmT00058 = new Object[] {
          new ParDef("@FlyghtArrivalAirportId",GXType.Int16,4,0)
          };
          Object[] prmT000510;
          prmT000510 = new Object[] {
          new ParDef("@FlyghtId",GXType.Int16,4,0)
          };
          Object[] prmT000512;
          prmT000512 = new Object[] {
          new ParDef("@FlyghtId",GXType.Int16,4,0)
          };
          Object[] prmT000514;
          prmT000514 = new Object[] {
          new ParDef("@FlyghtId",GXType.Int16,4,0)
          };
          Object[] prmT000515;
          prmT000515 = new Object[] {
          new ParDef("@FlyghtDepartureAirportId",GXType.Int16,4,0)
          };
          Object[] prmT000516;
          prmT000516 = new Object[] {
          new ParDef("@FlyghtArrivalAirportId",GXType.Int16,4,0)
          };
          Object[] prmT000517;
          prmT000517 = new Object[] {
          new ParDef("@AirlineID",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000518;
          prmT000518 = new Object[] {
          new ParDef("@FlyghtId",GXType.Int16,4,0)
          };
          Object[] prmT000519;
          prmT000519 = new Object[] {
          new ParDef("@FlyghtId",GXType.Int16,4,0)
          };
          Object[] prmT000520;
          prmT000520 = new Object[] {
          new ParDef("@FlyghtId",GXType.Int16,4,0)
          };
          Object[] prmT000521;
          prmT000521 = new Object[] {
          new ParDef("@FlyghtPrice",GXType.Decimal,9,2) ,
          new ParDef("@FlyghtPricePercentage",GXType.Int16,3,0) ,
          new ParDef("@AirlineID",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@FlyghtDepartureAirportId",GXType.Int16,4,0) ,
          new ParDef("@FlyghtArrivalAirportId",GXType.Int16,4,0)
          };
          Object[] prmT000522;
          prmT000522 = new Object[] {
          new ParDef("@FlyghtPrice",GXType.Decimal,9,2) ,
          new ParDef("@FlyghtPricePercentage",GXType.Int16,3,0) ,
          new ParDef("@AirlineID",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@FlyghtDepartureAirportId",GXType.Int16,4,0) ,
          new ParDef("@FlyghtArrivalAirportId",GXType.Int16,4,0) ,
          new ParDef("@FlyghtId",GXType.Int16,4,0)
          };
          Object[] prmT000523;
          prmT000523 = new Object[] {
          new ParDef("@FlyghtId",GXType.Int16,4,0)
          };
          Object[] prmT000525;
          prmT000525 = new Object[] {
          new ParDef("@FlyghtId",GXType.Int16,4,0)
          };
          Object[] prmT000526;
          prmT000526 = new Object[] {
          new ParDef("@FlyghtDepartureAirportId",GXType.Int16,4,0)
          };
          Object[] prmT000527;
          prmT000527 = new Object[] {
          new ParDef("@FlyghtArrivalAirportId",GXType.Int16,4,0)
          };
          Object[] prmT000528;
          prmT000528 = new Object[] {
          new ParDef("@AirlineID",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000529;
          prmT000529 = new Object[] {
          };
          Object[] prmT000530;
          prmT000530 = new Object[] {
          new ParDef("@FlyghtId",GXType.Int16,4,0) ,
          new ParDef("@FlyghtSeatId",GXType.Int16,4,0) ,
          new ParDef("@FlyghtSeatChar",GXType.NChar,1,0)
          };
          Object[] prmT000531;
          prmT000531 = new Object[] {
          new ParDef("@FlyghtId",GXType.Int16,4,0) ,
          new ParDef("@FlyghtSeatId",GXType.Int16,4,0) ,
          new ParDef("@FlyghtSeatChar",GXType.NChar,1,0)
          };
          Object[] prmT000532;
          prmT000532 = new Object[] {
          new ParDef("@FlyghtId",GXType.Int16,4,0) ,
          new ParDef("@FlyghtSeatId",GXType.Int16,4,0) ,
          new ParDef("@FlyghtSeatChar",GXType.NChar,1,0) ,
          new ParDef("@FlyghtSeatLocation",GXType.NChar,1,0)
          };
          Object[] prmT000533;
          prmT000533 = new Object[] {
          new ParDef("@FlyghtSeatLocation",GXType.NChar,1,0) ,
          new ParDef("@FlyghtId",GXType.Int16,4,0) ,
          new ParDef("@FlyghtSeatId",GXType.Int16,4,0) ,
          new ParDef("@FlyghtSeatChar",GXType.NChar,1,0)
          };
          Object[] prmT000534;
          prmT000534 = new Object[] {
          new ParDef("@FlyghtId",GXType.Int16,4,0) ,
          new ParDef("@FlyghtSeatId",GXType.Int16,4,0) ,
          new ParDef("@FlyghtSeatChar",GXType.NChar,1,0)
          };
          Object[] prmT000535;
          prmT000535 = new Object[] {
          new ParDef("@FlyghtId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00052", "SELECT [FlyghtId], [FlyghtSeatId], [FlyghtSeatChar], [FlyghtSeatLocation] FROM [FlyghtSeat] WITH (UPDLOCK) WHERE [FlyghtId] = @FlyghtId AND [FlyghtSeatId] = @FlyghtSeatId AND [FlyghtSeatChar] = @FlyghtSeatChar ",true, GxErrorMask.GX_NOMASK, false, this,prmT00052,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00053", "SELECT [FlyghtId], [FlyghtSeatId], [FlyghtSeatChar], [FlyghtSeatLocation] FROM [FlyghtSeat] WHERE [FlyghtId] = @FlyghtId AND [FlyghtSeatId] = @FlyghtSeatId AND [FlyghtSeatChar] = @FlyghtSeatChar ",true, GxErrorMask.GX_NOMASK, false, this,prmT00053,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00054", "SELECT [FlyghtId], [FlyghtPrice], [FlyghtPricePercentage], [AirlineID], [FlyghtDepartureAirportId] AS FlyghtDepartureAirportId, [FlyghtArrivalAirportId] AS FlyghtArrivalAirportId FROM [Flyght] WITH (UPDLOCK) WHERE [FlyghtId] = @FlyghtId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00054,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00055", "SELECT [FlyghtId], [FlyghtPrice], [FlyghtPricePercentage], [AirlineID], [FlyghtDepartureAirportId] AS FlyghtDepartureAirportId, [FlyghtArrivalAirportId] AS FlyghtArrivalAirportId FROM [Flyght] WHERE [FlyghtId] = @FlyghtId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00055,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00056", "SELECT [AirlineName], [AirlineDiscountPercentage] FROM [Airline] WHERE [AirlineID] = @AirlineID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00056,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00057", "SELECT [AirportName] AS FlyghtDepartureAirportName FROM [Airport] WHERE [AirportId] = @FlyghtDepartureAirportId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00057,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00058", "SELECT [AirportName] AS FlyghtArrivalAirportName FROM [Airport] WHERE [AirportId] = @FlyghtArrivalAirportId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00058,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000510", "SELECT COALESCE( T1.[FlyghtCapacity], 0) AS FlyghtCapacity FROM (SELECT COUNT(*) AS FlyghtCapacity, [FlyghtId] FROM [FlyghtSeat] WITH (UPDLOCK) GROUP BY [FlyghtId] ) T1 WHERE T1.[FlyghtId] = @FlyghtId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000510,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000512", "SELECT TM1.[FlyghtId], T3.[AirportName] AS FlyghtDepartureAirportName, T4.[AirportName] AS FlyghtArrivalAirportName, TM1.[FlyghtPrice], TM1.[FlyghtPricePercentage], T5.[AirlineName], T5.[AirlineDiscountPercentage], TM1.[AirlineID], TM1.[FlyghtDepartureAirportId] AS FlyghtDepartureAirportId, TM1.[FlyghtArrivalAirportId] AS FlyghtArrivalAirportId, COALESCE( T2.[FlyghtCapacity], 0) AS FlyghtCapacity FROM (((([Flyght] TM1 LEFT JOIN (SELECT COUNT(*) AS FlyghtCapacity, [FlyghtId] FROM [FlyghtSeat] GROUP BY [FlyghtId] ) T2 ON T2.[FlyghtId] = TM1.[FlyghtId]) INNER JOIN [Airport] T3 ON T3.[AirportId] = TM1.[FlyghtDepartureAirportId]) INNER JOIN [Airport] T4 ON T4.[AirportId] = TM1.[FlyghtArrivalAirportId]) LEFT JOIN [Airline] T5 ON T5.[AirlineID] = TM1.[AirlineID]) WHERE TM1.[FlyghtId] = @FlyghtId ORDER BY TM1.[FlyghtId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000512,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000514", "SELECT COALESCE( T1.[FlyghtCapacity], 0) AS FlyghtCapacity FROM (SELECT COUNT(*) AS FlyghtCapacity, [FlyghtId] FROM [FlyghtSeat] WITH (UPDLOCK) GROUP BY [FlyghtId] ) T1 WHERE T1.[FlyghtId] = @FlyghtId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000514,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000515", "SELECT [AirportName] AS FlyghtDepartureAirportName FROM [Airport] WHERE [AirportId] = @FlyghtDepartureAirportId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000515,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000516", "SELECT [AirportName] AS FlyghtArrivalAirportName FROM [Airport] WHERE [AirportId] = @FlyghtArrivalAirportId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000516,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000517", "SELECT [AirlineName], [AirlineDiscountPercentage] FROM [Airline] WHERE [AirlineID] = @AirlineID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000517,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000518", "SELECT [FlyghtId] FROM [Flyght] WHERE [FlyghtId] = @FlyghtId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000518,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000519", "SELECT TOP 1 [FlyghtId] FROM [Flyght] WHERE ( [FlyghtId] > @FlyghtId) ORDER BY [FlyghtId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000519,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000520", "SELECT TOP 1 [FlyghtId] FROM [Flyght] WHERE ( [FlyghtId] < @FlyghtId) ORDER BY [FlyghtId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000520,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000521", "INSERT INTO [Flyght]([FlyghtPrice], [FlyghtPricePercentage], [AirlineID], [FlyghtDepartureAirportId], [FlyghtArrivalAirportId]) VALUES(@FlyghtPrice, @FlyghtPricePercentage, @AirlineID, @FlyghtDepartureAirportId, @FlyghtArrivalAirportId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000521,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000522", "UPDATE [Flyght] SET [FlyghtPrice]=@FlyghtPrice, [FlyghtPricePercentage]=@FlyghtPricePercentage, [AirlineID]=@AirlineID, [FlyghtDepartureAirportId]=@FlyghtDepartureAirportId, [FlyghtArrivalAirportId]=@FlyghtArrivalAirportId  WHERE [FlyghtId] = @FlyghtId", GxErrorMask.GX_NOMASK,prmT000522)
             ,new CursorDef("T000523", "DELETE FROM [Flyght]  WHERE [FlyghtId] = @FlyghtId", GxErrorMask.GX_NOMASK,prmT000523)
             ,new CursorDef("T000525", "SELECT COALESCE( T1.[FlyghtCapacity], 0) AS FlyghtCapacity FROM (SELECT COUNT(*) AS FlyghtCapacity, [FlyghtId] FROM [FlyghtSeat] WITH (UPDLOCK) GROUP BY [FlyghtId] ) T1 WHERE T1.[FlyghtId] = @FlyghtId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000525,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000526", "SELECT [AirportName] AS FlyghtDepartureAirportName FROM [Airport] WHERE [AirportId] = @FlyghtDepartureAirportId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000526,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000527", "SELECT [AirportName] AS FlyghtArrivalAirportName FROM [Airport] WHERE [AirportId] = @FlyghtArrivalAirportId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000527,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000528", "SELECT [AirlineName], [AirlineDiscountPercentage] FROM [Airline] WHERE [AirlineID] = @AirlineID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000528,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000529", "SELECT [FlyghtId] FROM [Flyght] ORDER BY [FlyghtId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000529,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000530", "SELECT [FlyghtId], [FlyghtSeatId], [FlyghtSeatChar], [FlyghtSeatLocation] FROM [FlyghtSeat] WHERE [FlyghtId] = @FlyghtId and [FlyghtSeatId] = @FlyghtSeatId and [FlyghtSeatChar] = @FlyghtSeatChar ORDER BY [FlyghtId], [FlyghtSeatId], [FlyghtSeatChar] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000530,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000531", "SELECT [FlyghtId], [FlyghtSeatId], [FlyghtSeatChar] FROM [FlyghtSeat] WHERE [FlyghtId] = @FlyghtId AND [FlyghtSeatId] = @FlyghtSeatId AND [FlyghtSeatChar] = @FlyghtSeatChar ",true, GxErrorMask.GX_NOMASK, false, this,prmT000531,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000532", "INSERT INTO [FlyghtSeat]([FlyghtId], [FlyghtSeatId], [FlyghtSeatChar], [FlyghtSeatLocation]) VALUES(@FlyghtId, @FlyghtSeatId, @FlyghtSeatChar, @FlyghtSeatLocation)", GxErrorMask.GX_NOMASK,prmT000532)
             ,new CursorDef("T000533", "UPDATE [FlyghtSeat] SET [FlyghtSeatLocation]=@FlyghtSeatLocation  WHERE [FlyghtId] = @FlyghtId AND [FlyghtSeatId] = @FlyghtSeatId AND [FlyghtSeatChar] = @FlyghtSeatChar", GxErrorMask.GX_NOMASK,prmT000533)
             ,new CursorDef("T000534", "DELETE FROM [FlyghtSeat]  WHERE [FlyghtId] = @FlyghtId AND [FlyghtSeatId] = @FlyghtSeatId AND [FlyghtSeatChar] = @FlyghtSeatChar", GxErrorMask.GX_NOMASK,prmT000534)
             ,new CursorDef("T000535", "SELECT [FlyghtId], [FlyghtSeatId], [FlyghtSeatChar] FROM [FlyghtSeat] WHERE [FlyghtId] = @FlyghtId ORDER BY [FlyghtId], [FlyghtSeatId], [FlyghtSeatChar] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000535,11, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 50);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((short[]) buf[9])[0] = rslt.getShort(9);
                ((short[]) buf[10])[0] = rslt.getShort(10);
                ((short[]) buf[11])[0] = rslt.getShort(11);
                ((bool[]) buf[12])[0] = rslt.wasNull(11);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 19 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 21 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 22 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 23 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 24 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                return;
             case 25 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                return;
             case 29 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                return;
       }
    }

 }

}
