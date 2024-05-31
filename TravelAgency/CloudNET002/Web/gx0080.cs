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
   public class gx0080 : GXDataArea
   {
      public gx0080( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TravelAgency", true);
      }

      public gx0080( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_pFlyghtId )
      {
         this.AV9pFlyghtId = 0 ;
         ExecuteImpl();
         aP0_pFlyghtId=this.AV9pFlyghtId;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pFlyghtId");
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pFlyghtId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pFlyghtId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               gxnrGrid1_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               gxgrGrid1_refresh_invoke( ) ;
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV9pFlyghtId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV9pFlyghtId", StringUtil.LTrimStr( (decimal)(AV9pFlyghtId), 4, 0));
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid1_newrow_invoke( )
      {
         nRC_GXsfl_74 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_74"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_74_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_74_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_74_idx = GetPar( "sGXsfl_74_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid1_newrow( ) ;
         /* End function gxnrGrid1_newrow_invoke */
      }

      protected void gxgrGrid1_refresh_invoke( )
      {
         subGrid1_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid1_Rows"), "."), 18, MidpointRounding.ToEven));
         AV6cFlyghtId = (short)(Math.Round(NumberUtil.Val( GetPar( "cFlyghtId"), "."), 18, MidpointRounding.ToEven));
         AV7cFlyghtDepartureAirportId = (short)(Math.Round(NumberUtil.Val( GetPar( "cFlyghtDepartureAirportId"), "."), 18, MidpointRounding.ToEven));
         AV8cFlyghtArrivalAirportId = (short)(Math.Round(NumberUtil.Val( GetPar( "cFlyghtArrivalAirportId"), "."), 18, MidpointRounding.ToEven));
         AV11cFlyghtPrice = NumberUtil.Val( GetPar( "cFlyghtPrice"), ".");
         AV12cFlyghtPricePercentage = (short)(Math.Round(NumberUtil.Val( GetPar( "cFlyghtPricePercentage"), "."), 18, MidpointRounding.ToEven));
         AV13cAirlineID = (short)(Math.Round(NumberUtil.Val( GetPar( "cAirlineID"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cFlyghtId, AV7cFlyghtDepartureAirportId, AV8cFlyghtArrivalAirportId, AV11cFlyghtPrice, AV12cFlyghtPricePercentage, AV13cAirlineID) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid1_refresh_invoke */
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterprompt", "GeneXus.Programs.general.ui.masterprompt", new Object[] {context});
            MasterPageObj.setDataArea(this,true);
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

      public override short ExecuteStartEvent( )
      {
         PA0G2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0G2( ) ;
         }
         return gxajaxcallmode ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
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
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0080.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV9pFlyghtId,4,0))}, new string[] {"pFlyghtId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCFLYGHTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cFlyghtId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCFLYGHTDEPARTUREAIRPORTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cFlyghtDepartureAirportId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCFLYGHTARRIVALAIRPORTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cFlyghtArrivalAirportId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCFLYGHTPRICE", StringUtil.LTrim( StringUtil.NToC( AV11cFlyghtPrice, 9, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCFLYGHTPRICEPERCENTAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cFlyghtPricePercentage), 3, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCAIRLINEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13cAirlineID), 4, 0, ".", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_74", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_74), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPFLYGHTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9pFlyghtId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "FLYGHTIDFILTERCONTAINER_Class", StringUtil.RTrim( divFlyghtidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "FLYGHTDEPARTUREAIRPORTIDFILTERCONTAINER_Class", StringUtil.RTrim( divFlyghtdepartureairportidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "FLYGHTARRIVALAIRPORTIDFILTERCONTAINER_Class", StringUtil.RTrim( divFlyghtarrivalairportidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "FLYGHTPRICEFILTERCONTAINER_Class", StringUtil.RTrim( divFlyghtpricefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "FLYGHTPRICEPERCENTAGEFILTERCONTAINER_Class", StringUtil.RTrim( divFlyghtpricepercentagefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "AIRLINEIDFILTERCONTAINER_Class", StringUtil.RTrim( divAirlineidfiltercontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", "notset");
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
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

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0G2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0G2( ) ;
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
         return formatLink("gx0080.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV9pFlyghtId,4,0))}, new string[] {"pFlyghtId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0080" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Flyght" ;
      }

      protected void WB0G0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMain_Internalname, 1, 0, "px", 0, "px", "ContainerFluid PromptContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 PromptAdvancedBarCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedcontainer_Internalname, 1, 0, "px", 0, "px", divAdvancedcontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFlyghtidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divFlyghtidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblflyghtidfilter_Internalname, "Flyght Id", "", "", lblLblflyghtidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e110g1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCflyghtid_Internalname, "Flyght Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCflyghtid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cFlyghtId), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCflyghtid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cFlyghtId), "ZZZ9") : context.localUtil.Format( (decimal)(AV6cFlyghtId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCflyghtid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCflyghtid_Visible, edtavCflyghtid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, divFlyghtdepartureairportidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divFlyghtdepartureairportidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblflyghtdepartureairportidfilter_Internalname, "Flyght Departure Airport Id", "", "", lblLblflyghtdepartureairportidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e120g1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCflyghtdepartureairportid_Internalname, "Flyght Departure Airport Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCflyghtdepartureairportid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cFlyghtDepartureAirportId), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCflyghtdepartureairportid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7cFlyghtDepartureAirportId), "ZZZ9") : context.localUtil.Format( (decimal)(AV7cFlyghtDepartureAirportId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCflyghtdepartureairportid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCflyghtdepartureairportid_Visible, edtavCflyghtdepartureairportid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, divFlyghtarrivalairportidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divFlyghtarrivalairportidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblflyghtarrivalairportidfilter_Internalname, "Flyght Arrival Airport Id", "", "", lblLblflyghtarrivalairportidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e130g1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCflyghtarrivalairportid_Internalname, "Flyght Arrival Airport Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCflyghtarrivalairportid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cFlyghtArrivalAirportId), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCflyghtarrivalairportid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8cFlyghtArrivalAirportId), "ZZZ9") : context.localUtil.Format( (decimal)(AV8cFlyghtArrivalAirportId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCflyghtarrivalairportid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCflyghtarrivalairportid_Visible, edtavCflyghtarrivalairportid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, divFlyghtpricefiltercontainer_Internalname, 1, 0, "px", 0, "px", divFlyghtpricefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblflyghtpricefilter_Internalname, "Flyght Price", "", "", lblLblflyghtpricefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e140g1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCflyghtprice_Internalname, "Flyght Price", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCflyghtprice_Internalname, StringUtil.LTrim( StringUtil.NToC( AV11cFlyghtPrice, 9, 2, ".", "")), StringUtil.LTrim( ((edtavCflyghtprice_Enabled!=0) ? context.localUtil.Format( AV11cFlyghtPrice, "ZZZZZ9.99") : context.localUtil.Format( AV11cFlyghtPrice, "ZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCflyghtprice_Jsonclick, 0, "Attribute", "", "", "", "", edtavCflyghtprice_Visible, edtavCflyghtprice_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, divFlyghtpricepercentagefiltercontainer_Internalname, 1, 0, "px", 0, "px", divFlyghtpricepercentagefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblflyghtpricepercentagefilter_Internalname, "Flyght Price Percentage", "", "", lblLblflyghtpricepercentagefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e150g1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCflyghtpricepercentage_Internalname, "Flyght Price Percentage", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCflyghtpricepercentage_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cFlyghtPricePercentage), 3, 0, ".", "")), StringUtil.LTrim( ((edtavCflyghtpricepercentage_Enabled!=0) ? context.localUtil.Format( (decimal)(AV12cFlyghtPricePercentage), "ZZ9") : context.localUtil.Format( (decimal)(AV12cFlyghtPricePercentage), "ZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCflyghtpricepercentage_Jsonclick, 0, "Attribute", "", "", "", "", edtavCflyghtpricepercentage_Visible, edtavCflyghtpricepercentage_Enabled, 0, "text", "1", 3, "chr", 1, "row", 3, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, divAirlineidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divAirlineidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblairlineidfilter_Internalname, "Airline ID", "", "", lblLblairlineidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e160g1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCairlineid_Internalname, "Airline ID", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCairlineid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13cAirlineID), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCairlineid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV13cAirlineID), "ZZZ9") : context.localUtil.Format( (decimal)(AV13cAirlineID), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCairlineid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCairlineid_Visible, edtavCairlineid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 WWGridCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-sm hidden-md hidden-lg ToggleCell", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e170g1_client"+"'", TempTags, "", 2, "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl74( ) ;
         }
         if ( wbEnd == 74 )
         {
            wbEnd = 0;
            nRC_GXsfl_74 = (int)(nGXsfl_74_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
               Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 74 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
                  Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0G2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_9-182098", 0) ;
            }
         }
         Form.Meta.addItem("description", "Selection List Flyght", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0G0( ) ;
      }

      protected void WS0G2( )
      {
         START0G2( ) ;
         EVT0G2( ) ;
      }

      protected void EVT0G2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
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
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRID1PAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid1_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid1_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid1_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid1_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_74_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
                              SubsflControlProps_742( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV14Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_74_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A20FlyghtId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtFlyghtId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A22FlyghtDepartureAirportId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtFlyghtDepartureAirportId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A25FlyghtArrivalAirportId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtFlyghtArrivalAirportId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A27FlyghtPrice = context.localUtil.CToN( cgiGet( edtFlyghtPrice_Internalname), ".", ",");
                              A28FlyghtPricePercentage = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtFlyghtPricePercentage_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A30AirlineID = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtAirlineID_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              n30AirlineID = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E180G2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E190G2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cflyghtid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCFLYGHTID"), ".", ",") != Convert.ToDecimal( AV6cFlyghtId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cflyghtdepartureairportid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCFLYGHTDEPARTUREAIRPORTID"), ".", ",") != Convert.ToDecimal( AV7cFlyghtDepartureAirportId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cflyghtarrivalairportid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCFLYGHTARRIVALAIRPORTID"), ".", ",") != Convert.ToDecimal( AV8cFlyghtArrivalAirportId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cflyghtprice Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCFLYGHTPRICE"), ".", ",") != AV11cFlyghtPrice )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cflyghtpricepercentage Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCFLYGHTPRICEPERCENTAGE"), ".", ",") != Convert.ToDecimal( AV12cFlyghtPricePercentage )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cairlineid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCAIRLINEID"), ".", ",") != Convert.ToDecimal( AV13cAirlineID )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E200G2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0G2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA0G2( )
      {
         if ( nDonePA == 0 )
         {
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
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_742( ) ;
         while ( nGXsfl_74_idx <= nRC_GXsfl_74 )
         {
            sendrow_742( ) ;
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        short AV6cFlyghtId ,
                                        short AV7cFlyghtDepartureAirportId ,
                                        short AV8cFlyghtArrivalAirportId ,
                                        decimal AV11cFlyghtPrice ,
                                        short AV12cFlyghtPricePercentage ,
                                        short AV13cAirlineID )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF0G2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_FLYGHTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A20FlyghtId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "FLYGHTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A20FlyghtId), 4, 0, ".", "")));
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0G2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF0G2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 74;
         nGXsfl_74_idx = 1;
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_742( ) ;
         bGXsfl_74_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "PromptGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_742( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cFlyghtDepartureAirportId ,
                                                 AV8cFlyghtArrivalAirportId ,
                                                 AV11cFlyghtPrice ,
                                                 AV12cFlyghtPricePercentage ,
                                                 AV13cAirlineID ,
                                                 A22FlyghtDepartureAirportId ,
                                                 A25FlyghtArrivalAirportId ,
                                                 A27FlyghtPrice ,
                                                 A28FlyghtPricePercentage ,
                                                 A30AirlineID ,
                                                 AV6cFlyghtId } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT,
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor H000G2 */
            pr_default.execute(0, new Object[] {AV6cFlyghtId, AV7cFlyghtDepartureAirportId, AV8cFlyghtArrivalAirportId, AV11cFlyghtPrice, AV12cFlyghtPricePercentage, AV13cAirlineID, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_74_idx = 1;
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A30AirlineID = H000G2_A30AirlineID[0];
               n30AirlineID = H000G2_n30AirlineID[0];
               A28FlyghtPricePercentage = H000G2_A28FlyghtPricePercentage[0];
               A27FlyghtPrice = H000G2_A27FlyghtPrice[0];
               A25FlyghtArrivalAirportId = H000G2_A25FlyghtArrivalAirportId[0];
               A22FlyghtDepartureAirportId = H000G2_A22FlyghtDepartureAirportId[0];
               A20FlyghtId = H000G2_A20FlyghtId[0];
               /* Execute user event: Load */
               E190G2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 74;
            WB0G0( ) ;
         }
         bGXsfl_74_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0G2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_FLYGHTID"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, context.localUtil.Format( (decimal)(A20FlyghtId), "ZZZ9"), context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV7cFlyghtDepartureAirportId ,
                                              AV8cFlyghtArrivalAirportId ,
                                              AV11cFlyghtPrice ,
                                              AV12cFlyghtPricePercentage ,
                                              AV13cAirlineID ,
                                              A22FlyghtDepartureAirportId ,
                                              A25FlyghtArrivalAirportId ,
                                              A27FlyghtPrice ,
                                              A28FlyghtPricePercentage ,
                                              A30AirlineID ,
                                              AV6cFlyghtId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT
                                              }
         });
         /* Using cursor H000G3 */
         pr_default.execute(1, new Object[] {AV6cFlyghtId, AV7cFlyghtDepartureAirportId, AV8cFlyghtArrivalAirportId, AV11cFlyghtPrice, AV12cFlyghtPricePercentage, AV13cAirlineID});
         GRID1_nRecordCount = H000G3_AGRID1_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID1_nRecordCount) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(10*1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cFlyghtId, AV7cFlyghtDepartureAirportId, AV8cFlyghtArrivalAirportId, AV11cFlyghtPrice, AV12cFlyghtPricePercentage, AV13cAirlineID) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ( GRID1_nRecordCount >= subGrid1_fnc_Recordsperpage( ) ) && ( GRID1_nEOF == 0 ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cFlyghtId, AV7cFlyghtDepartureAirportId, AV8cFlyghtArrivalAirportId, AV11cFlyghtPrice, AV12cFlyghtPricePercentage, AV13cAirlineID) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_fnc_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage-subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cFlyghtId, AV7cFlyghtDepartureAirportId, AV8cFlyghtArrivalAirportId, AV11cFlyghtPrice, AV12cFlyghtPricePercentage, AV13cAirlineID) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( GRID1_nRecordCount > subGrid1_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-subGrid1_fnc_Recordsperpage( ));
            }
            else
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cFlyghtId, AV7cFlyghtDepartureAirportId, AV8cFlyghtArrivalAirportId, AV11cFlyghtPrice, AV12cFlyghtPricePercentage, AV13cAirlineID) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cFlyghtId, AV7cFlyghtDepartureAirportId, AV8cFlyghtArrivalAirportId, AV11cFlyghtPrice, AV12cFlyghtPricePercentage, AV13cAirlineID) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtFlyghtId_Enabled = 0;
         AssignProp("", false, edtFlyghtId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlyghtId_Enabled), 5, 0), !bGXsfl_74_Refreshing);
         edtFlyghtDepartureAirportId_Enabled = 0;
         AssignProp("", false, edtFlyghtDepartureAirportId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlyghtDepartureAirportId_Enabled), 5, 0), !bGXsfl_74_Refreshing);
         edtFlyghtArrivalAirportId_Enabled = 0;
         AssignProp("", false, edtFlyghtArrivalAirportId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlyghtArrivalAirportId_Enabled), 5, 0), !bGXsfl_74_Refreshing);
         edtFlyghtPrice_Enabled = 0;
         AssignProp("", false, edtFlyghtPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlyghtPrice_Enabled), 5, 0), !bGXsfl_74_Refreshing);
         edtFlyghtPricePercentage_Enabled = 0;
         AssignProp("", false, edtFlyghtPricePercentage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlyghtPricePercentage_Enabled), 5, 0), !bGXsfl_74_Refreshing);
         edtAirlineID_Enabled = 0;
         AssignProp("", false, edtAirlineID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAirlineID_Enabled), 5, 0), !bGXsfl_74_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0G0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E180G2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_74 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_74"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCflyghtid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCflyghtid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCFLYGHTID");
               GX_FocusControl = edtavCflyghtid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cFlyghtId = 0;
               AssignAttri("", false, "AV6cFlyghtId", StringUtil.LTrimStr( (decimal)(AV6cFlyghtId), 4, 0));
            }
            else
            {
               AV6cFlyghtId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCflyghtid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cFlyghtId", StringUtil.LTrimStr( (decimal)(AV6cFlyghtId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCflyghtdepartureairportid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCflyghtdepartureairportid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCFLYGHTDEPARTUREAIRPORTID");
               GX_FocusControl = edtavCflyghtdepartureairportid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cFlyghtDepartureAirportId = 0;
               AssignAttri("", false, "AV7cFlyghtDepartureAirportId", StringUtil.LTrimStr( (decimal)(AV7cFlyghtDepartureAirportId), 4, 0));
            }
            else
            {
               AV7cFlyghtDepartureAirportId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCflyghtdepartureairportid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7cFlyghtDepartureAirportId", StringUtil.LTrimStr( (decimal)(AV7cFlyghtDepartureAirportId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCflyghtarrivalairportid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCflyghtarrivalairportid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCFLYGHTARRIVALAIRPORTID");
               GX_FocusControl = edtavCflyghtarrivalairportid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cFlyghtArrivalAirportId = 0;
               AssignAttri("", false, "AV8cFlyghtArrivalAirportId", StringUtil.LTrimStr( (decimal)(AV8cFlyghtArrivalAirportId), 4, 0));
            }
            else
            {
               AV8cFlyghtArrivalAirportId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCflyghtarrivalairportid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8cFlyghtArrivalAirportId", StringUtil.LTrimStr( (decimal)(AV8cFlyghtArrivalAirportId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCflyghtprice_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCflyghtprice_Internalname), ".", ",") > 999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCFLYGHTPRICE");
               GX_FocusControl = edtavCflyghtprice_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cFlyghtPrice = 0;
               AssignAttri("", false, "AV11cFlyghtPrice", StringUtil.LTrimStr( AV11cFlyghtPrice, 9, 2));
            }
            else
            {
               AV11cFlyghtPrice = context.localUtil.CToN( cgiGet( edtavCflyghtprice_Internalname), ".", ",");
               AssignAttri("", false, "AV11cFlyghtPrice", StringUtil.LTrimStr( AV11cFlyghtPrice, 9, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCflyghtpricepercentage_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCflyghtpricepercentage_Internalname), ".", ",") > Convert.ToDecimal( 999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCFLYGHTPRICEPERCENTAGE");
               GX_FocusControl = edtavCflyghtpricepercentage_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cFlyghtPricePercentage = 0;
               AssignAttri("", false, "AV12cFlyghtPricePercentage", StringUtil.LTrimStr( (decimal)(AV12cFlyghtPricePercentage), 3, 0));
            }
            else
            {
               AV12cFlyghtPricePercentage = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCflyghtpricepercentage_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12cFlyghtPricePercentage", StringUtil.LTrimStr( (decimal)(AV12cFlyghtPricePercentage), 3, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCairlineid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCairlineid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCAIRLINEID");
               GX_FocusControl = edtavCairlineid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV13cAirlineID = 0;
               AssignAttri("", false, "AV13cAirlineID", StringUtil.LTrimStr( (decimal)(AV13cAirlineID), 4, 0));
            }
            else
            {
               AV13cAirlineID = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCairlineid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13cAirlineID", StringUtil.LTrimStr( (decimal)(AV13cAirlineID), 4, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCFLYGHTID"), ".", ",") != Convert.ToDecimal( AV6cFlyghtId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCFLYGHTDEPARTUREAIRPORTID"), ".", ",") != Convert.ToDecimal( AV7cFlyghtDepartureAirportId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCFLYGHTARRIVALAIRPORTID"), ".", ",") != Convert.ToDecimal( AV8cFlyghtArrivalAirportId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCFLYGHTPRICE"), ".", ",") != AV11cFlyghtPrice )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCFLYGHTPRICEPERCENTAGE"), ".", ",") != Convert.ToDecimal( AV12cFlyghtPricePercentage )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCAIRLINEID"), ".", ",") != Convert.ToDecimal( AV13cAirlineID )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E180G2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E180G2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Selection List %1", "Flyght", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV10ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E190G2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "selectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV14Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
         sendrow_742( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_74_Refreshing )
         {
            DoAjaxLoad(74, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E200G2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E200G2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV9pFlyghtId = A20FlyghtId;
         AssignAttri("", false, "AV9pFlyghtId", StringUtil.LTrimStr( (decimal)(AV9pFlyghtId), 4, 0));
         context.setWebReturnParms(new Object[] {(short)AV9pFlyghtId});
         context.setWebReturnParmsMetadata(new Object[] {"AV9pFlyghtId"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV9pFlyghtId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV9pFlyghtId", StringUtil.LTrimStr( (decimal)(AV9pFlyghtId), 4, 0));
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA0G2( ) ;
         WS0G2( ) ;
         WE0G2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202452916155345", true, true);
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
         context.AddJavascriptSource("gx0080.js", "?202452916155345", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_idx;
         edtFlyghtId_Internalname = "FLYGHTID_"+sGXsfl_74_idx;
         edtFlyghtDepartureAirportId_Internalname = "FLYGHTDEPARTUREAIRPORTID_"+sGXsfl_74_idx;
         edtFlyghtArrivalAirportId_Internalname = "FLYGHTARRIVALAIRPORTID_"+sGXsfl_74_idx;
         edtFlyghtPrice_Internalname = "FLYGHTPRICE_"+sGXsfl_74_idx;
         edtFlyghtPricePercentage_Internalname = "FLYGHTPRICEPERCENTAGE_"+sGXsfl_74_idx;
         edtAirlineID_Internalname = "AIRLINEID_"+sGXsfl_74_idx;
      }

      protected void SubsflControlProps_fel_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_fel_idx;
         edtFlyghtId_Internalname = "FLYGHTID_"+sGXsfl_74_fel_idx;
         edtFlyghtDepartureAirportId_Internalname = "FLYGHTDEPARTUREAIRPORTID_"+sGXsfl_74_fel_idx;
         edtFlyghtArrivalAirportId_Internalname = "FLYGHTARRIVALAIRPORTID_"+sGXsfl_74_fel_idx;
         edtFlyghtPrice_Internalname = "FLYGHTPRICE_"+sGXsfl_74_fel_idx;
         edtFlyghtPricePercentage_Internalname = "FLYGHTPRICEPERCENTAGE_"+sGXsfl_74_fel_idx;
         edtAirlineID_Internalname = "AIRLINEID_"+sGXsfl_74_fel_idx;
      }

      protected void sendrow_742( )
      {
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_742( ) ;
         WB0G0( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_74_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid1Row = GXWebRow.GetNew(context,Grid1Container);
            if ( subGrid1_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid1_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
            else if ( subGrid1_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid1_Backstyle = 0;
               subGrid1_Backcolor = subGrid1_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Uniform";
               }
            }
            else if ( subGrid1_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
               subGrid1_Backcolor = (int)(0x0);
            }
            else if ( subGrid1_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( ((int)((nGXsfl_74_idx) % (2))) == 0 )
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Even";
                  }
               }
               else
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Odd";
                  }
               }
            }
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_74_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A20FlyghtId), 4, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_74_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV14Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV14Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            edtFlyghtId_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A20FlyghtId), 4, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtFlyghtId_Internalname, "Link", edtFlyghtId_Link, !bGXsfl_74_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFlyghtId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A20FlyghtId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A20FlyghtId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtFlyghtId_Link,(string)"",(string)"",(string)"",(string)edtFlyghtId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFlyghtDepartureAirportId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A22FlyghtDepartureAirportId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A22FlyghtDepartureAirportId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFlyghtDepartureAirportId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFlyghtArrivalAirportId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A25FlyghtArrivalAirportId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A25FlyghtArrivalAirportId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFlyghtArrivalAirportId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFlyghtPrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A27FlyghtPrice, 9, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A27FlyghtPrice, "ZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFlyghtPrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFlyghtPricePercentage_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A28FlyghtPricePercentage), 3, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A28FlyghtPricePercentage), "ZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFlyghtPricePercentage_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)3,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Percentage",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAirlineID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A30AirlineID), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A30AirlineID), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAirlineID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes0G2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         /* End function sendrow_742 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl74( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"74\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid1_Backcolorstyle == 0 )
            {
               subGrid1_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid1_Class) > 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Title";
               }
            }
            else
            {
               subGrid1_Titlebackstyle = 1;
               if ( subGrid1_Backcolorstyle == 1 )
               {
                  subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"SelectionAttribute"+" "+((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Departure Airport Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Arrival Airport Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Price Percentage") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Airline ID") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Grid1Container.AddObjectProperty("GridName", "Grid1");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               Grid1Container = new GXWebGrid( context);
            }
            else
            {
               Grid1Container.Clear();
            }
            Grid1Container.SetWrapped(nGXWrapped);
            Grid1Container.AddObjectProperty("GridName", "Grid1");
            Grid1Container.AddObjectProperty("Header", subGrid1_Header);
            Grid1Container.AddObjectProperty("Class", "PromptGrid");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( AV5LinkSelection));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtavLinkselection_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A20FlyghtId), 4, 0, ".", ""))));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtFlyghtId_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A22FlyghtDepartureAirportId), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A25FlyghtArrivalAirportId), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A27FlyghtPrice, 9, 2, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A28FlyghtPricePercentage), 3, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A30AirlineID), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblLblflyghtidfilter_Internalname = "LBLFLYGHTIDFILTER";
         edtavCflyghtid_Internalname = "vCFLYGHTID";
         divFlyghtidfiltercontainer_Internalname = "FLYGHTIDFILTERCONTAINER";
         lblLblflyghtdepartureairportidfilter_Internalname = "LBLFLYGHTDEPARTUREAIRPORTIDFILTER";
         edtavCflyghtdepartureairportid_Internalname = "vCFLYGHTDEPARTUREAIRPORTID";
         divFlyghtdepartureairportidfiltercontainer_Internalname = "FLYGHTDEPARTUREAIRPORTIDFILTERCONTAINER";
         lblLblflyghtarrivalairportidfilter_Internalname = "LBLFLYGHTARRIVALAIRPORTIDFILTER";
         edtavCflyghtarrivalairportid_Internalname = "vCFLYGHTARRIVALAIRPORTID";
         divFlyghtarrivalairportidfiltercontainer_Internalname = "FLYGHTARRIVALAIRPORTIDFILTERCONTAINER";
         lblLblflyghtpricefilter_Internalname = "LBLFLYGHTPRICEFILTER";
         edtavCflyghtprice_Internalname = "vCFLYGHTPRICE";
         divFlyghtpricefiltercontainer_Internalname = "FLYGHTPRICEFILTERCONTAINER";
         lblLblflyghtpricepercentagefilter_Internalname = "LBLFLYGHTPRICEPERCENTAGEFILTER";
         edtavCflyghtpricepercentage_Internalname = "vCFLYGHTPRICEPERCENTAGE";
         divFlyghtpricepercentagefiltercontainer_Internalname = "FLYGHTPRICEPERCENTAGEFILTERCONTAINER";
         lblLblairlineidfilter_Internalname = "LBLAIRLINEIDFILTER";
         edtavCairlineid_Internalname = "vCAIRLINEID";
         divAirlineidfiltercontainer_Internalname = "AIRLINEIDFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtFlyghtId_Internalname = "FLYGHTID";
         edtFlyghtDepartureAirportId_Internalname = "FLYGHTDEPARTUREAIRPORTID";
         edtFlyghtArrivalAirportId_Internalname = "FLYGHTARRIVALAIRPORTID";
         edtFlyghtPrice_Internalname = "FLYGHTPRICE";
         edtFlyghtPricePercentage_Internalname = "FLYGHTPRICEPERCENTAGE";
         edtAirlineID_Internalname = "AIRLINEID";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         divGridtable_Internalname = "GRIDTABLE";
         divMain_Internalname = "MAIN";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("TravelAgency", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         edtAirlineID_Jsonclick = "";
         edtFlyghtPricePercentage_Jsonclick = "";
         edtFlyghtPrice_Jsonclick = "";
         edtFlyghtArrivalAirportId_Jsonclick = "";
         edtFlyghtDepartureAirportId_Jsonclick = "";
         edtFlyghtId_Jsonclick = "";
         edtFlyghtId_Link = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtAirlineID_Enabled = 0;
         edtFlyghtPricePercentage_Enabled = 0;
         edtFlyghtPrice_Enabled = 0;
         edtFlyghtArrivalAirportId_Enabled = 0;
         edtFlyghtDepartureAirportId_Enabled = 0;
         edtFlyghtId_Enabled = 0;
         edtavCairlineid_Jsonclick = "";
         edtavCairlineid_Enabled = 1;
         edtavCairlineid_Visible = 1;
         edtavCflyghtpricepercentage_Jsonclick = "";
         edtavCflyghtpricepercentage_Enabled = 1;
         edtavCflyghtpricepercentage_Visible = 1;
         edtavCflyghtprice_Jsonclick = "";
         edtavCflyghtprice_Enabled = 1;
         edtavCflyghtprice_Visible = 1;
         edtavCflyghtarrivalairportid_Jsonclick = "";
         edtavCflyghtarrivalairportid_Enabled = 1;
         edtavCflyghtarrivalairportid_Visible = 1;
         edtavCflyghtdepartureairportid_Jsonclick = "";
         edtavCflyghtdepartureairportid_Enabled = 1;
         edtavCflyghtdepartureairportid_Visible = 1;
         edtavCflyghtid_Jsonclick = "";
         edtavCflyghtid_Enabled = 1;
         edtavCflyghtid_Visible = 1;
         divAirlineidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divFlyghtpricepercentagefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divFlyghtpricefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divFlyghtarrivalairportidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divFlyghtdepartureairportidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divFlyghtidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Flyght";
         subGrid1_Rows = 10;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cFlyghtId","fld":"vCFLYGHTID","pic":"ZZZ9"},{"av":"AV7cFlyghtDepartureAirportId","fld":"vCFLYGHTDEPARTUREAIRPORTID","pic":"ZZZ9"},{"av":"AV8cFlyghtArrivalAirportId","fld":"vCFLYGHTARRIVALAIRPORTID","pic":"ZZZ9"},{"av":"AV11cFlyghtPrice","fld":"vCFLYGHTPRICE","pic":"ZZZZZ9.99"},{"av":"AV12cFlyghtPricePercentage","fld":"vCFLYGHTPRICEPERCENTAGE","pic":"ZZ9"},{"av":"AV13cAirlineID","fld":"vCAIRLINEID","pic":"ZZZ9"}]}""");
         setEventMetadata("'TOGGLE'","""{"handler":"E170G1","iparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]""");
         setEventMetadata("'TOGGLE'",""","oparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]}""");
         setEventMetadata("LBLFLYGHTIDFILTER.CLICK","""{"handler":"E110G1","iparms":[{"av":"divFlyghtidfiltercontainer_Class","ctrl":"FLYGHTIDFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLFLYGHTIDFILTER.CLICK",""","oparms":[{"av":"divFlyghtidfiltercontainer_Class","ctrl":"FLYGHTIDFILTERCONTAINER","prop":"Class"},{"av":"edtavCflyghtid_Visible","ctrl":"vCFLYGHTID","prop":"Visible"}]}""");
         setEventMetadata("LBLFLYGHTDEPARTUREAIRPORTIDFILTER.CLICK","""{"handler":"E120G1","iparms":[{"av":"divFlyghtdepartureairportidfiltercontainer_Class","ctrl":"FLYGHTDEPARTUREAIRPORTIDFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLFLYGHTDEPARTUREAIRPORTIDFILTER.CLICK",""","oparms":[{"av":"divFlyghtdepartureairportidfiltercontainer_Class","ctrl":"FLYGHTDEPARTUREAIRPORTIDFILTERCONTAINER","prop":"Class"},{"av":"edtavCflyghtdepartureairportid_Visible","ctrl":"vCFLYGHTDEPARTUREAIRPORTID","prop":"Visible"}]}""");
         setEventMetadata("LBLFLYGHTARRIVALAIRPORTIDFILTER.CLICK","""{"handler":"E130G1","iparms":[{"av":"divFlyghtarrivalairportidfiltercontainer_Class","ctrl":"FLYGHTARRIVALAIRPORTIDFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLFLYGHTARRIVALAIRPORTIDFILTER.CLICK",""","oparms":[{"av":"divFlyghtarrivalairportidfiltercontainer_Class","ctrl":"FLYGHTARRIVALAIRPORTIDFILTERCONTAINER","prop":"Class"},{"av":"edtavCflyghtarrivalairportid_Visible","ctrl":"vCFLYGHTARRIVALAIRPORTID","prop":"Visible"}]}""");
         setEventMetadata("LBLFLYGHTPRICEFILTER.CLICK","""{"handler":"E140G1","iparms":[{"av":"divFlyghtpricefiltercontainer_Class","ctrl":"FLYGHTPRICEFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLFLYGHTPRICEFILTER.CLICK",""","oparms":[{"av":"divFlyghtpricefiltercontainer_Class","ctrl":"FLYGHTPRICEFILTERCONTAINER","prop":"Class"},{"av":"edtavCflyghtprice_Visible","ctrl":"vCFLYGHTPRICE","prop":"Visible"}]}""");
         setEventMetadata("LBLFLYGHTPRICEPERCENTAGEFILTER.CLICK","""{"handler":"E150G1","iparms":[{"av":"divFlyghtpricepercentagefiltercontainer_Class","ctrl":"FLYGHTPRICEPERCENTAGEFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLFLYGHTPRICEPERCENTAGEFILTER.CLICK",""","oparms":[{"av":"divFlyghtpricepercentagefiltercontainer_Class","ctrl":"FLYGHTPRICEPERCENTAGEFILTERCONTAINER","prop":"Class"},{"av":"edtavCflyghtpricepercentage_Visible","ctrl":"vCFLYGHTPRICEPERCENTAGE","prop":"Visible"}]}""");
         setEventMetadata("LBLAIRLINEIDFILTER.CLICK","""{"handler":"E160G1","iparms":[{"av":"divAirlineidfiltercontainer_Class","ctrl":"AIRLINEIDFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLAIRLINEIDFILTER.CLICK",""","oparms":[{"av":"divAirlineidfiltercontainer_Class","ctrl":"AIRLINEIDFILTERCONTAINER","prop":"Class"},{"av":"edtavCairlineid_Visible","ctrl":"vCAIRLINEID","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E200G2","iparms":[{"av":"A20FlyghtId","fld":"FLYGHTID","pic":"ZZZ9","hsh":true}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV9pFlyghtId","fld":"vPFLYGHTID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRID1_FIRSTPAGE","""{"handler":"subgrid1_firstpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cFlyghtId","fld":"vCFLYGHTID","pic":"ZZZ9"},{"av":"AV7cFlyghtDepartureAirportId","fld":"vCFLYGHTDEPARTUREAIRPORTID","pic":"ZZZ9"},{"av":"AV8cFlyghtArrivalAirportId","fld":"vCFLYGHTARRIVALAIRPORTID","pic":"ZZZ9"},{"av":"AV11cFlyghtPrice","fld":"vCFLYGHTPRICE","pic":"ZZZZZ9.99"},{"av":"AV12cFlyghtPricePercentage","fld":"vCFLYGHTPRICEPERCENTAGE","pic":"ZZ9"},{"av":"AV13cAirlineID","fld":"vCAIRLINEID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRID1_PREVPAGE","""{"handler":"subgrid1_previouspage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cFlyghtId","fld":"vCFLYGHTID","pic":"ZZZ9"},{"av":"AV7cFlyghtDepartureAirportId","fld":"vCFLYGHTDEPARTUREAIRPORTID","pic":"ZZZ9"},{"av":"AV8cFlyghtArrivalAirportId","fld":"vCFLYGHTARRIVALAIRPORTID","pic":"ZZZ9"},{"av":"AV11cFlyghtPrice","fld":"vCFLYGHTPRICE","pic":"ZZZZZ9.99"},{"av":"AV12cFlyghtPricePercentage","fld":"vCFLYGHTPRICEPERCENTAGE","pic":"ZZ9"},{"av":"AV13cAirlineID","fld":"vCAIRLINEID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRID1_NEXTPAGE","""{"handler":"subgrid1_nextpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cFlyghtId","fld":"vCFLYGHTID","pic":"ZZZ9"},{"av":"AV7cFlyghtDepartureAirportId","fld":"vCFLYGHTDEPARTUREAIRPORTID","pic":"ZZZ9"},{"av":"AV8cFlyghtArrivalAirportId","fld":"vCFLYGHTARRIVALAIRPORTID","pic":"ZZZ9"},{"av":"AV11cFlyghtPrice","fld":"vCFLYGHTPRICE","pic":"ZZZZZ9.99"},{"av":"AV12cFlyghtPricePercentage","fld":"vCFLYGHTPRICEPERCENTAGE","pic":"ZZ9"},{"av":"AV13cAirlineID","fld":"vCAIRLINEID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRID1_LASTPAGE","""{"handler":"subgrid1_lastpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cFlyghtId","fld":"vCFLYGHTID","pic":"ZZZ9"},{"av":"AV7cFlyghtDepartureAirportId","fld":"vCFLYGHTDEPARTUREAIRPORTID","pic":"ZZZ9"},{"av":"AV8cFlyghtArrivalAirportId","fld":"vCFLYGHTARRIVALAIRPORTID","pic":"ZZZ9"},{"av":"AV11cFlyghtPrice","fld":"vCFLYGHTPRICE","pic":"ZZZZZ9.99"},{"av":"AV12cFlyghtPricePercentage","fld":"vCFLYGHTPRICEPERCENTAGE","pic":"ZZ9"},{"av":"AV13cAirlineID","fld":"vCAIRLINEID","pic":"ZZZ9"}]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Airlineid","iparms":[]}""");
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

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblflyghtidfilter_Jsonclick = "";
         TempTags = "";
         lblLblflyghtdepartureairportidfilter_Jsonclick = "";
         lblLblflyghtarrivalairportidfilter_Jsonclick = "";
         lblLblflyghtpricefilter_Jsonclick = "";
         lblLblflyghtpricepercentagefilter_Jsonclick = "";
         lblLblairlineidfilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5LinkSelection = "";
         AV14Linkselection_GXI = "";
         H000G2_A30AirlineID = new short[1] ;
         H000G2_n30AirlineID = new bool[] {false} ;
         H000G2_A28FlyghtPricePercentage = new short[1] ;
         H000G2_A27FlyghtPrice = new decimal[1] ;
         H000G2_A25FlyghtArrivalAirportId = new short[1] ;
         H000G2_A22FlyghtDepartureAirportId = new short[1] ;
         H000G2_A20FlyghtId = new short[1] ;
         H000G3_AGRID1_nRecordCount = new long[1] ;
         AV10ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0080__default(),
            new Object[][] {
                new Object[] {
               H000G2_A30AirlineID, H000G2_n30AirlineID, H000G2_A28FlyghtPricePercentage, H000G2_A27FlyghtPrice, H000G2_A25FlyghtArrivalAirportId, H000G2_A22FlyghtDepartureAirportId, H000G2_A20FlyghtId
               }
               , new Object[] {
               H000G3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV9pFlyghtId ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV6cFlyghtId ;
      private short AV7cFlyghtDepartureAirportId ;
      private short AV8cFlyghtArrivalAirportId ;
      private short AV12cFlyghtPricePercentage ;
      private short AV13cAirlineID ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A20FlyghtId ;
      private short A22FlyghtDepartureAirportId ;
      private short A25FlyghtArrivalAirportId ;
      private short A28FlyghtPricePercentage ;
      private short A30AirlineID ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private int nRC_GXsfl_74 ;
      private int subGrid1_Rows ;
      private int nGXsfl_74_idx=1 ;
      private int edtavCflyghtid_Enabled ;
      private int edtavCflyghtid_Visible ;
      private int edtavCflyghtdepartureairportid_Enabled ;
      private int edtavCflyghtdepartureairportid_Visible ;
      private int edtavCflyghtarrivalairportid_Enabled ;
      private int edtavCflyghtarrivalairportid_Visible ;
      private int edtavCflyghtprice_Enabled ;
      private int edtavCflyghtprice_Visible ;
      private int edtavCflyghtpricepercentage_Enabled ;
      private int edtavCflyghtpricepercentage_Visible ;
      private int edtavCairlineid_Enabled ;
      private int edtavCairlineid_Visible ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtFlyghtId_Enabled ;
      private int edtFlyghtDepartureAirportId_Enabled ;
      private int edtFlyghtArrivalAirportId_Enabled ;
      private int edtFlyghtPrice_Enabled ;
      private int edtFlyghtPricePercentage_Enabled ;
      private int edtAirlineID_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private decimal AV11cFlyghtPrice ;
      private decimal A27FlyghtPrice ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divFlyghtidfiltercontainer_Class ;
      private string divFlyghtdepartureairportidfiltercontainer_Class ;
      private string divFlyghtarrivalairportidfiltercontainer_Class ;
      private string divFlyghtpricefiltercontainer_Class ;
      private string divFlyghtpricepercentagefiltercontainer_Class ;
      private string divAirlineidfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_74_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divFlyghtidfiltercontainer_Internalname ;
      private string lblLblflyghtidfilter_Internalname ;
      private string lblLblflyghtidfilter_Jsonclick ;
      private string edtavCflyghtid_Internalname ;
      private string TempTags ;
      private string edtavCflyghtid_Jsonclick ;
      private string divFlyghtdepartureairportidfiltercontainer_Internalname ;
      private string lblLblflyghtdepartureairportidfilter_Internalname ;
      private string lblLblflyghtdepartureairportidfilter_Jsonclick ;
      private string edtavCflyghtdepartureairportid_Internalname ;
      private string edtavCflyghtdepartureairportid_Jsonclick ;
      private string divFlyghtarrivalairportidfiltercontainer_Internalname ;
      private string lblLblflyghtarrivalairportidfilter_Internalname ;
      private string lblLblflyghtarrivalairportidfilter_Jsonclick ;
      private string edtavCflyghtarrivalairportid_Internalname ;
      private string edtavCflyghtarrivalairportid_Jsonclick ;
      private string divFlyghtpricefiltercontainer_Internalname ;
      private string lblLblflyghtpricefilter_Internalname ;
      private string lblLblflyghtpricefilter_Jsonclick ;
      private string edtavCflyghtprice_Internalname ;
      private string edtavCflyghtprice_Jsonclick ;
      private string divFlyghtpricepercentagefiltercontainer_Internalname ;
      private string lblLblflyghtpricepercentagefilter_Internalname ;
      private string lblLblflyghtpricepercentagefilter_Jsonclick ;
      private string edtavCflyghtpricepercentage_Internalname ;
      private string edtavCflyghtpricepercentage_Jsonclick ;
      private string divAirlineidfiltercontainer_Internalname ;
      private string lblLblairlineidfilter_Internalname ;
      private string lblLblairlineidfilter_Jsonclick ;
      private string edtavCairlineid_Internalname ;
      private string edtavCairlineid_Jsonclick ;
      private string divGridtable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLinkselection_Internalname ;
      private string edtFlyghtId_Internalname ;
      private string edtFlyghtDepartureAirportId_Internalname ;
      private string edtFlyghtArrivalAirportId_Internalname ;
      private string edtFlyghtPrice_Internalname ;
      private string edtFlyghtPricePercentage_Internalname ;
      private string edtAirlineID_Internalname ;
      private string AV10ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_74_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtFlyghtId_Link ;
      private string edtFlyghtId_Jsonclick ;
      private string edtFlyghtDepartureAirportId_Jsonclick ;
      private string edtFlyghtArrivalAirportId_Jsonclick ;
      private string edtFlyghtPrice_Jsonclick ;
      private string edtFlyghtPricePercentage_Jsonclick ;
      private string edtAirlineID_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_74_Refreshing=false ;
      private bool n30AirlineID ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV14Linkselection_GXI ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H000G2_A30AirlineID ;
      private bool[] H000G2_n30AirlineID ;
      private short[] H000G2_A28FlyghtPricePercentage ;
      private decimal[] H000G2_A27FlyghtPrice ;
      private short[] H000G2_A25FlyghtArrivalAirportId ;
      private short[] H000G2_A22FlyghtDepartureAirportId ;
      private short[] H000G2_A20FlyghtId ;
      private long[] H000G3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short aP0_pFlyghtId ;
   }

   public class gx0080__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000G2( IGxContext context ,
                                             short AV7cFlyghtDepartureAirportId ,
                                             short AV8cFlyghtArrivalAirportId ,
                                             decimal AV11cFlyghtPrice ,
                                             short AV12cFlyghtPricePercentage ,
                                             short AV13cAirlineID ,
                                             short A22FlyghtDepartureAirportId ,
                                             short A25FlyghtArrivalAirportId ,
                                             decimal A27FlyghtPrice ,
                                             short A28FlyghtPricePercentage ,
                                             short A30AirlineID ,
                                             short AV6cFlyghtId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [AirlineID], [FlyghtPricePercentage], [FlyghtPrice], [FlyghtArrivalAirportId], [FlyghtDepartureAirportId], [FlyghtId]";
         sFromString = " FROM [Flyght]";
         sOrderString = "";
         AddWhere(sWhereString, "([FlyghtId] >= @AV6cFlyghtId)");
         if ( ! (0==AV7cFlyghtDepartureAirportId) )
         {
            AddWhere(sWhereString, "([FlyghtDepartureAirportId] >= @AV7cFlyghtDepartureAirportId)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV8cFlyghtArrivalAirportId) )
         {
            AddWhere(sWhereString, "([FlyghtArrivalAirportId] >= @AV8cFlyghtArrivalAirportId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV11cFlyghtPrice) )
         {
            AddWhere(sWhereString, "([FlyghtPrice] >= @AV11cFlyghtPrice)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV12cFlyghtPricePercentage) )
         {
            AddWhere(sWhereString, "([FlyghtPricePercentage] >= @AV12cFlyghtPricePercentage)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV13cAirlineID) )
         {
            AddWhere(sWhereString, "([AirlineID] >= @AV13cAirlineID)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         sOrderString += " ORDER BY [FlyghtId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H000G3( IGxContext context ,
                                             short AV7cFlyghtDepartureAirportId ,
                                             short AV8cFlyghtArrivalAirportId ,
                                             decimal AV11cFlyghtPrice ,
                                             short AV12cFlyghtPricePercentage ,
                                             short AV13cAirlineID ,
                                             short A22FlyghtDepartureAirportId ,
                                             short A25FlyghtArrivalAirportId ,
                                             decimal A27FlyghtPrice ,
                                             short A28FlyghtPricePercentage ,
                                             short A30AirlineID ,
                                             short AV6cFlyghtId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Flyght]";
         AddWhere(sWhereString, "([FlyghtId] >= @AV6cFlyghtId)");
         if ( ! (0==AV7cFlyghtDepartureAirportId) )
         {
            AddWhere(sWhereString, "([FlyghtDepartureAirportId] >= @AV7cFlyghtDepartureAirportId)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV8cFlyghtArrivalAirportId) )
         {
            AddWhere(sWhereString, "([FlyghtArrivalAirportId] >= @AV8cFlyghtArrivalAirportId)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV11cFlyghtPrice) )
         {
            AddWhere(sWhereString, "([FlyghtPrice] >= @AV11cFlyghtPrice)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV12cFlyghtPricePercentage) )
         {
            AddWhere(sWhereString, "([FlyghtPricePercentage] >= @AV12cFlyghtPricePercentage)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV13cAirlineID) )
         {
            AddWhere(sWhereString, "([AirlineID] >= @AV13cAirlineID)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H000G2(context, (short)dynConstraints[0] , (short)dynConstraints[1] , (decimal)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] , (decimal)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] );
               case 1 :
                     return conditional_H000G3(context, (short)dynConstraints[0] , (short)dynConstraints[1] , (decimal)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] , (decimal)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000G2;
          prmH000G2 = new Object[] {
          new ParDef("@AV6cFlyghtId",GXType.Int16,4,0) ,
          new ParDef("@AV7cFlyghtDepartureAirportId",GXType.Int16,4,0) ,
          new ParDef("@AV8cFlyghtArrivalAirportId",GXType.Int16,4,0) ,
          new ParDef("@AV11cFlyghtPrice",GXType.Decimal,9,2) ,
          new ParDef("@AV12cFlyghtPricePercentage",GXType.Int16,3,0) ,
          new ParDef("@AV13cAirlineID",GXType.Int16,4,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000G3;
          prmH000G3 = new Object[] {
          new ParDef("@AV6cFlyghtId",GXType.Int16,4,0) ,
          new ParDef("@AV7cFlyghtDepartureAirportId",GXType.Int16,4,0) ,
          new ParDef("@AV8cFlyghtArrivalAirportId",GXType.Int16,4,0) ,
          new ParDef("@AV11cFlyghtPrice",GXType.Decimal,9,2) ,
          new ParDef("@AV12cFlyghtPricePercentage",GXType.Int16,3,0) ,
          new ParDef("@AV13cAirlineID",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000G2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000G2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H000G3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000G3,1, GxCacheFrequency.OFF ,false,false )
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
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
