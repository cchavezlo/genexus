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
   public class gx00a1 : GXDataArea
   {
      public gx00a1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TravelAgency", true);
      }

      public gx00a1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_pFlyghtId ,
                           out short aP1_pFlyghtSeatId )
      {
         this.AV9pFlyghtId = aP0_pFlyghtId;
         this.AV10pFlyghtSeatId = 0 ;
         ExecuteImpl();
         aP1_pFlyghtSeatId=this.AV10pFlyghtSeatId;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavCflyghtseatlocation = new GXCombobox();
         cmbavCflyghtseatchar = new GXCombobox();
         cmbFlyghtSeatLocation = new GXCombobox();
         cmbFlyghtSeatChar = new GXCombobox();
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
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV10pFlyghtSeatId = (short)(Math.Round(NumberUtil.Val( GetPar( "pFlyghtSeatId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV10pFlyghtSeatId", StringUtil.LTrimStr( (decimal)(AV10pFlyghtSeatId), 4, 0));
               }
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
         nRC_GXsfl_44 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_44"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_44_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_44_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_44_idx = GetPar( "sGXsfl_44_idx");
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
         AV6cFlyghtSeatId = (short)(Math.Round(NumberUtil.Val( GetPar( "cFlyghtSeatId"), "."), 18, MidpointRounding.ToEven));
         cmbavCflyghtseatlocation.FromJSonString( GetNextPar( ));
         AV7cFlyghtSeatLocation = GetPar( "cFlyghtSeatLocation");
         cmbavCflyghtseatchar.FromJSonString( GetNextPar( ));
         AV8cFlyghtSeatChar = GetPar( "cFlyghtSeatChar");
         AV9pFlyghtId = (short)(Math.Round(NumberUtil.Val( GetPar( "pFlyghtId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cFlyghtSeatId, AV7cFlyghtSeatLocation, AV8cFlyghtSeatChar, AV9pFlyghtId) ;
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
         PA0J2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0J2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00a1.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV9pFlyghtId,4,0)),UrlEncode(StringUtil.LTrimStr(AV10pFlyghtSeatId,4,0))}, new string[] {"pFlyghtId","pFlyghtSeatId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCFLYGHTSEATID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cFlyghtSeatId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCFLYGHTSEATLOCATION", StringUtil.RTrim( AV7cFlyghtSeatLocation));
         GxWebStd.gx_hidden_field( context, "GXH_vCFLYGHTSEATCHAR", StringUtil.RTrim( AV8cFlyghtSeatChar));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_44", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_44), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPFLYGHTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9pFlyghtId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPFLYGHTSEATID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10pFlyghtSeatId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "FLYGHTSEATIDFILTERCONTAINER_Class", StringUtil.RTrim( divFlyghtseatidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "FLYGHTSEATLOCATIONFILTERCONTAINER_Class", StringUtil.RTrim( divFlyghtseatlocationfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "FLYGHTSEATCHARFILTERCONTAINER_Class", StringUtil.RTrim( divFlyghtseatcharfiltercontainer_Class));
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
            WE0J2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0J2( ) ;
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
         return formatLink("gx00a1.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV9pFlyghtId,4,0)),UrlEncode(StringUtil.LTrimStr(AV10pFlyghtSeatId,4,0))}, new string[] {"pFlyghtId","pFlyghtSeatId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00A1" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Seat" ;
      }

      protected void WB0J0( )
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
            GxWebStd.gx_div_start( context, divFlyghtseatidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divFlyghtseatidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblflyghtseatidfilter_Internalname, "Flyght Seat Id", "", "", lblLblflyghtseatidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e110j1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00A1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCflyghtseatid_Internalname, "Flyght Seat Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_44_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCflyghtseatid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cFlyghtSeatId), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCflyghtseatid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cFlyghtSeatId), "ZZZ9") : context.localUtil.Format( (decimal)(AV6cFlyghtSeatId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCflyghtseatid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCflyghtseatid_Visible, edtavCflyghtseatid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx00A1.htm");
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
            GxWebStd.gx_div_start( context, divFlyghtseatlocationfiltercontainer_Internalname, 1, 0, "px", 0, "px", divFlyghtseatlocationfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblflyghtseatlocationfilter_Internalname, "Flyght Seat Location", "", "", lblLblflyghtseatlocationfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e120j1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00A1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCflyghtseatlocation_Internalname, "Flyght Seat Location", "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_44_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCflyghtseatlocation, cmbavCflyghtseatlocation_Internalname, StringUtil.RTrim( AV7cFlyghtSeatLocation), 1, cmbavCflyghtseatlocation_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavCflyghtseatlocation.Visible, cmbavCflyghtseatlocation.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "", true, 0, "HLP_Gx00A1.htm");
            cmbavCflyghtseatlocation.CurrentValue = StringUtil.RTrim( AV7cFlyghtSeatLocation);
            AssignProp("", false, cmbavCflyghtseatlocation_Internalname, "Values", (string)(cmbavCflyghtseatlocation.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divFlyghtseatcharfiltercontainer_Internalname, 1, 0, "px", 0, "px", divFlyghtseatcharfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblflyghtseatcharfilter_Internalname, "Flyght Seat Char", "", "", lblLblflyghtseatcharfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e130j1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00A1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCflyghtseatchar_Internalname, "Flyght Seat Char", "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_44_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCflyghtseatchar, cmbavCflyghtseatchar_Internalname, StringUtil.RTrim( AV8cFlyghtSeatChar), 1, cmbavCflyghtseatchar_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavCflyghtseatchar.Visible, cmbavCflyghtseatchar.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "", true, 0, "HLP_Gx00A1.htm");
            cmbavCflyghtseatchar.CurrentValue = StringUtil.RTrim( AV8cFlyghtSeatChar);
            AssignProp("", false, cmbavCflyghtseatchar_Internalname, "Values", (string)(cmbavCflyghtseatchar.ToJavascriptSource()), true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(44), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e140j1_client"+"'", TempTags, "", 2, "HLP_Gx00A1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl44( ) ;
         }
         if ( wbEnd == 44 )
         {
            wbEnd = 0;
            nRC_GXsfl_44 = (int)(nGXsfl_44_idx-1);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(44), 2, 0)+","+"null"+");", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00A1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 44 )
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

      protected void START0J2( )
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
         Form.Meta.addItem("description", "Selection List Seat", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0J0( ) ;
      }

      protected void WS0J2( )
      {
         START0J2( ) ;
         EVT0J2( ) ;
      }

      protected void EVT0J2( )
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
                              nGXsfl_44_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_44_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_44_idx), 4, 0), 4, "0");
                              SubsflControlProps_442( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV12Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_44_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A33FlyghtSeatId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtFlyghtSeatId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              cmbFlyghtSeatLocation.Name = cmbFlyghtSeatLocation_Internalname;
                              cmbFlyghtSeatLocation.CurrentValue = cgiGet( cmbFlyghtSeatLocation_Internalname);
                              A34FlyghtSeatLocation = cgiGet( cmbFlyghtSeatLocation_Internalname);
                              cmbFlyghtSeatChar.Name = cmbFlyghtSeatChar_Internalname;
                              cmbFlyghtSeatChar.CurrentValue = cgiGet( cmbFlyghtSeatChar_Internalname);
                              A35FlyghtSeatChar = cgiGet( cmbFlyghtSeatChar_Internalname);
                              A20FlyghtId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtFlyghtId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E150J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E160J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cflyghtseatid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCFLYGHTSEATID"), ".", ",") != Convert.ToDecimal( AV6cFlyghtSeatId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cflyghtseatlocation Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCFLYGHTSEATLOCATION"), AV7cFlyghtSeatLocation) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cflyghtseatchar Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCFLYGHTSEATCHAR"), AV8cFlyghtSeatChar) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E170J2 ();
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

      protected void WE0J2( )
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

      protected void PA0J2( )
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
         SubsflControlProps_442( ) ;
         while ( nGXsfl_44_idx <= nRC_GXsfl_44 )
         {
            sendrow_442( ) ;
            nGXsfl_44_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_44_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_44_idx+1);
            sGXsfl_44_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_44_idx), 4, 0), 4, "0");
            SubsflControlProps_442( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        short AV6cFlyghtSeatId ,
                                        string AV7cFlyghtSeatLocation ,
                                        string AV8cFlyghtSeatChar ,
                                        short AV9pFlyghtId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF0J2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_FLYGHTSEATID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A33FlyghtSeatId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "FLYGHTSEATID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A33FlyghtSeatId), 4, 0, ".", "")));
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
         if ( cmbavCflyghtseatlocation.ItemCount > 0 )
         {
            AV7cFlyghtSeatLocation = cmbavCflyghtseatlocation.getValidValue(AV7cFlyghtSeatLocation);
            AssignAttri("", false, "AV7cFlyghtSeatLocation", AV7cFlyghtSeatLocation);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCflyghtseatlocation.CurrentValue = StringUtil.RTrim( AV7cFlyghtSeatLocation);
            AssignProp("", false, cmbavCflyghtseatlocation_Internalname, "Values", cmbavCflyghtseatlocation.ToJavascriptSource(), true);
         }
         if ( cmbavCflyghtseatchar.ItemCount > 0 )
         {
            AV8cFlyghtSeatChar = cmbavCflyghtseatchar.getValidValue(AV8cFlyghtSeatChar);
            AssignAttri("", false, "AV8cFlyghtSeatChar", AV8cFlyghtSeatChar);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCflyghtseatchar.CurrentValue = StringUtil.RTrim( AV8cFlyghtSeatChar);
            AssignProp("", false, cmbavCflyghtseatchar_Internalname, "Values", cmbavCflyghtseatchar.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0J2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF0J2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 44;
         nGXsfl_44_idx = 1;
         sGXsfl_44_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_44_idx), 4, 0), 4, "0");
         SubsflControlProps_442( ) ;
         bGXsfl_44_Refreshing = true;
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
            SubsflControlProps_442( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cFlyghtSeatLocation ,
                                                 AV8cFlyghtSeatChar ,
                                                 A34FlyghtSeatLocation ,
                                                 A35FlyghtSeatChar ,
                                                 AV9pFlyghtId ,
                                                 AV6cFlyghtSeatId ,
                                                 A20FlyghtId } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV7cFlyghtSeatLocation = StringUtil.PadR( StringUtil.RTrim( AV7cFlyghtSeatLocation), 1, "%");
            lV8cFlyghtSeatChar = StringUtil.PadR( StringUtil.RTrim( AV8cFlyghtSeatChar), 1, "%");
            /* Using cursor H000J2 */
            pr_default.execute(0, new Object[] {AV9pFlyghtId, AV6cFlyghtSeatId, lV7cFlyghtSeatLocation, lV8cFlyghtSeatChar, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_44_idx = 1;
            sGXsfl_44_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_44_idx), 4, 0), 4, "0");
            SubsflControlProps_442( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A20FlyghtId = H000J2_A20FlyghtId[0];
               A35FlyghtSeatChar = H000J2_A35FlyghtSeatChar[0];
               A34FlyghtSeatLocation = H000J2_A34FlyghtSeatLocation[0];
               A33FlyghtSeatId = H000J2_A33FlyghtSeatId[0];
               /* Execute user event: Load */
               E160J2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 44;
            WB0J0( ) ;
         }
         bGXsfl_44_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0J2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_FLYGHTSEATID"+"_"+sGXsfl_44_idx, GetSecureSignedToken( sGXsfl_44_idx, context.localUtil.Format( (decimal)(A33FlyghtSeatId), "ZZZ9"), context));
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
                                              AV7cFlyghtSeatLocation ,
                                              AV8cFlyghtSeatChar ,
                                              A34FlyghtSeatLocation ,
                                              A35FlyghtSeatChar ,
                                              AV9pFlyghtId ,
                                              AV6cFlyghtSeatId ,
                                              A20FlyghtId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV7cFlyghtSeatLocation = StringUtil.PadR( StringUtil.RTrim( AV7cFlyghtSeatLocation), 1, "%");
         lV8cFlyghtSeatChar = StringUtil.PadR( StringUtil.RTrim( AV8cFlyghtSeatChar), 1, "%");
         /* Using cursor H000J3 */
         pr_default.execute(1, new Object[] {AV9pFlyghtId, AV6cFlyghtSeatId, lV7cFlyghtSeatLocation, lV8cFlyghtSeatChar});
         GRID1_nRecordCount = H000J3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cFlyghtSeatId, AV7cFlyghtSeatLocation, AV8cFlyghtSeatChar, AV9pFlyghtId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cFlyghtSeatId, AV7cFlyghtSeatLocation, AV8cFlyghtSeatChar, AV9pFlyghtId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cFlyghtSeatId, AV7cFlyghtSeatLocation, AV8cFlyghtSeatChar, AV9pFlyghtId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cFlyghtSeatId, AV7cFlyghtSeatLocation, AV8cFlyghtSeatChar, AV9pFlyghtId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cFlyghtSeatId, AV7cFlyghtSeatLocation, AV8cFlyghtSeatChar, AV9pFlyghtId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtFlyghtSeatId_Enabled = 0;
         AssignProp("", false, edtFlyghtSeatId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlyghtSeatId_Enabled), 5, 0), !bGXsfl_44_Refreshing);
         cmbFlyghtSeatLocation.Enabled = 0;
         AssignProp("", false, cmbFlyghtSeatLocation_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbFlyghtSeatLocation.Enabled), 5, 0), !bGXsfl_44_Refreshing);
         cmbFlyghtSeatChar.Enabled = 0;
         AssignProp("", false, cmbFlyghtSeatChar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbFlyghtSeatChar.Enabled), 5, 0), !bGXsfl_44_Refreshing);
         edtFlyghtId_Enabled = 0;
         AssignProp("", false, edtFlyghtId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlyghtId_Enabled), 5, 0), !bGXsfl_44_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0J0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E150J2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_44 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_44"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCflyghtseatid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCflyghtseatid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCFLYGHTSEATID");
               GX_FocusControl = edtavCflyghtseatid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cFlyghtSeatId = 0;
               AssignAttri("", false, "AV6cFlyghtSeatId", StringUtil.LTrimStr( (decimal)(AV6cFlyghtSeatId), 4, 0));
            }
            else
            {
               AV6cFlyghtSeatId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCflyghtseatid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cFlyghtSeatId", StringUtil.LTrimStr( (decimal)(AV6cFlyghtSeatId), 4, 0));
            }
            cmbavCflyghtseatlocation.Name = cmbavCflyghtseatlocation_Internalname;
            cmbavCflyghtseatlocation.CurrentValue = cgiGet( cmbavCflyghtseatlocation_Internalname);
            AV7cFlyghtSeatLocation = cgiGet( cmbavCflyghtseatlocation_Internalname);
            AssignAttri("", false, "AV7cFlyghtSeatLocation", AV7cFlyghtSeatLocation);
            cmbavCflyghtseatchar.Name = cmbavCflyghtseatchar_Internalname;
            cmbavCflyghtseatchar.CurrentValue = cgiGet( cmbavCflyghtseatchar_Internalname);
            AV8cFlyghtSeatChar = cgiGet( cmbavCflyghtseatchar_Internalname);
            AssignAttri("", false, "AV8cFlyghtSeatChar", AV8cFlyghtSeatChar);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCFLYGHTSEATID"), ".", ",") != Convert.ToDecimal( AV6cFlyghtSeatId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCFLYGHTSEATLOCATION"), AV7cFlyghtSeatLocation) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCFLYGHTSEATCHAR"), AV8cFlyghtSeatChar) != 0 )
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
         E150J2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E150J2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Selection List %1", "Seat", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV11ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E160J2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "selectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV12Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
         sendrow_442( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_44_Refreshing )
         {
            DoAjaxLoad(44, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E170J2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E170J2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV10pFlyghtSeatId = A33FlyghtSeatId;
         AssignAttri("", false, "AV10pFlyghtSeatId", StringUtil.LTrimStr( (decimal)(AV10pFlyghtSeatId), 4, 0));
         context.setWebReturnParms(new Object[] {(short)AV10pFlyghtSeatId});
         context.setWebReturnParmsMetadata(new Object[] {"AV10pFlyghtSeatId"});
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
         AV10pFlyghtSeatId = Convert.ToInt16(getParm(obj,1));
         AssignAttri("", false, "AV10pFlyghtSeatId", StringUtil.LTrimStr( (decimal)(AV10pFlyghtSeatId), 4, 0));
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
         PA0J2( ) ;
         WS0J2( ) ;
         WE0J2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20245291732253", true, true);
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
         context.AddJavascriptSource("gx00a1.js", "?20245291732253", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_442( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_44_idx;
         edtFlyghtSeatId_Internalname = "FLYGHTSEATID_"+sGXsfl_44_idx;
         cmbFlyghtSeatLocation_Internalname = "FLYGHTSEATLOCATION_"+sGXsfl_44_idx;
         cmbFlyghtSeatChar_Internalname = "FLYGHTSEATCHAR_"+sGXsfl_44_idx;
         edtFlyghtId_Internalname = "FLYGHTID_"+sGXsfl_44_idx;
      }

      protected void SubsflControlProps_fel_442( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_44_fel_idx;
         edtFlyghtSeatId_Internalname = "FLYGHTSEATID_"+sGXsfl_44_fel_idx;
         cmbFlyghtSeatLocation_Internalname = "FLYGHTSEATLOCATION_"+sGXsfl_44_fel_idx;
         cmbFlyghtSeatChar_Internalname = "FLYGHTSEATCHAR_"+sGXsfl_44_fel_idx;
         edtFlyghtId_Internalname = "FLYGHTID_"+sGXsfl_44_fel_idx;
      }

      protected void sendrow_442( )
      {
         sGXsfl_44_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_44_idx), 4, 0), 4, "0");
         SubsflControlProps_442( ) ;
         WB0J0( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_44_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_44_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_44_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A33FlyghtSeatId), 4, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_44_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV12Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV12Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFlyghtSeatId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A33FlyghtSeatId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A33FlyghtSeatId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFlyghtSeatId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)44,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbFlyghtSeatLocation.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "FLYGHTSEATLOCATION_" + sGXsfl_44_idx;
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
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbFlyghtSeatLocation,(string)cmbFlyghtSeatLocation_Internalname,StringUtil.RTrim( A34FlyghtSeatLocation),(short)1,(string)cmbFlyghtSeatLocation_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn OptionalColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbFlyghtSeatLocation.CurrentValue = StringUtil.RTrim( A34FlyghtSeatLocation);
            AssignProp("", false, cmbFlyghtSeatLocation_Internalname, "Values", (string)(cmbFlyghtSeatLocation.ToJavascriptSource()), !bGXsfl_44_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbFlyghtSeatChar.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "FLYGHTSEATCHAR_" + sGXsfl_44_idx;
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
            }
            /* ComboBox */
            Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbFlyghtSeatChar,(string)cmbFlyghtSeatChar_Internalname,StringUtil.RTrim( A35FlyghtSeatChar),(short)1,(string)cmbFlyghtSeatChar_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"DescriptionAttribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbFlyghtSeatChar.CurrentValue = StringUtil.RTrim( A35FlyghtSeatChar);
            AssignProp("", false, cmbFlyghtSeatChar_Internalname, "Values", (string)(cmbFlyghtSeatChar.ToJavascriptSource()), !bGXsfl_44_Refreshing);
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFlyghtId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A20FlyghtId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A20FlyghtId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFlyghtId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)44,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes0J2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_44_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_44_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_44_idx+1);
            sGXsfl_44_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_44_idx), 4, 0), 4, "0");
            SubsflControlProps_442( ) ;
         }
         /* End function sendrow_442 */
      }

      protected void init_web_controls( )
      {
         cmbavCflyghtseatlocation.Name = "vCFLYGHTSEATLOCATION";
         cmbavCflyghtseatlocation.WebTags = "";
         cmbavCflyghtseatlocation.addItem("W", "Window", 0);
         cmbavCflyghtseatlocation.addItem("M", "Midle", 0);
         cmbavCflyghtseatlocation.addItem("A", "Aisle", 0);
         if ( cmbavCflyghtseatlocation.ItemCount > 0 )
         {
            AV7cFlyghtSeatLocation = cmbavCflyghtseatlocation.getValidValue(AV7cFlyghtSeatLocation);
            AssignAttri("", false, "AV7cFlyghtSeatLocation", AV7cFlyghtSeatLocation);
         }
         cmbavCflyghtseatchar.Name = "vCFLYGHTSEATCHAR";
         cmbavCflyghtseatchar.WebTags = "";
         cmbavCflyghtseatchar.addItem("A", "A", 0);
         cmbavCflyghtseatchar.addItem("B", "B", 0);
         cmbavCflyghtseatchar.addItem("C", "C", 0);
         cmbavCflyghtseatchar.addItem("D", "D", 0);
         cmbavCflyghtseatchar.addItem("E", "E", 0);
         cmbavCflyghtseatchar.addItem("F", "F", 0);
         if ( cmbavCflyghtseatchar.ItemCount > 0 )
         {
            AV8cFlyghtSeatChar = cmbavCflyghtseatchar.getValidValue(AV8cFlyghtSeatChar);
            AssignAttri("", false, "AV8cFlyghtSeatChar", AV8cFlyghtSeatChar);
         }
         GXCCtl = "FLYGHTSEATLOCATION_" + sGXsfl_44_idx;
         cmbFlyghtSeatLocation.Name = GXCCtl;
         cmbFlyghtSeatLocation.WebTags = "";
         cmbFlyghtSeatLocation.addItem("W", "Window", 0);
         cmbFlyghtSeatLocation.addItem("M", "Midle", 0);
         cmbFlyghtSeatLocation.addItem("A", "Aisle", 0);
         if ( cmbFlyghtSeatLocation.ItemCount > 0 )
         {
            A34FlyghtSeatLocation = cmbFlyghtSeatLocation.getValidValue(A34FlyghtSeatLocation);
         }
         GXCCtl = "FLYGHTSEATCHAR_" + sGXsfl_44_idx;
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
         /* End function init_web_controls */
      }

      protected void StartGridControl44( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"44\">") ;
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
            context.SendWebValue( "Seat Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Seat Location") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Seat Char") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Flyght Id") ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A33FlyghtSeatId), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A34FlyghtSeatLocation)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A35FlyghtSeatChar)));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( cmbFlyghtSeatChar.Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A20FlyghtId), 4, 0, ".", ""))));
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
         lblLblflyghtseatidfilter_Internalname = "LBLFLYGHTSEATIDFILTER";
         edtavCflyghtseatid_Internalname = "vCFLYGHTSEATID";
         divFlyghtseatidfiltercontainer_Internalname = "FLYGHTSEATIDFILTERCONTAINER";
         lblLblflyghtseatlocationfilter_Internalname = "LBLFLYGHTSEATLOCATIONFILTER";
         cmbavCflyghtseatlocation_Internalname = "vCFLYGHTSEATLOCATION";
         divFlyghtseatlocationfiltercontainer_Internalname = "FLYGHTSEATLOCATIONFILTERCONTAINER";
         lblLblflyghtseatcharfilter_Internalname = "LBLFLYGHTSEATCHARFILTER";
         cmbavCflyghtseatchar_Internalname = "vCFLYGHTSEATCHAR";
         divFlyghtseatcharfiltercontainer_Internalname = "FLYGHTSEATCHARFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtFlyghtSeatId_Internalname = "FLYGHTSEATID";
         cmbFlyghtSeatLocation_Internalname = "FLYGHTSEATLOCATION";
         cmbFlyghtSeatChar_Internalname = "FLYGHTSEATCHAR";
         edtFlyghtId_Internalname = "FLYGHTID";
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
         cmbFlyghtSeatChar.Link = "";
         subGrid1_Header = "";
         edtFlyghtId_Jsonclick = "";
         cmbFlyghtSeatChar_Jsonclick = "";
         cmbFlyghtSeatLocation_Jsonclick = "";
         edtFlyghtSeatId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtFlyghtId_Enabled = 0;
         cmbFlyghtSeatChar.Enabled = 0;
         cmbFlyghtSeatLocation.Enabled = 0;
         edtFlyghtSeatId_Enabled = 0;
         cmbavCflyghtseatchar_Jsonclick = "";
         cmbavCflyghtseatchar.Visible = 1;
         cmbavCflyghtseatchar.Enabled = 1;
         cmbavCflyghtseatlocation_Jsonclick = "";
         cmbavCflyghtseatlocation.Visible = 1;
         cmbavCflyghtseatlocation.Enabled = 1;
         edtavCflyghtseatid_Jsonclick = "";
         edtavCflyghtseatid_Enabled = 1;
         edtavCflyghtseatid_Visible = 1;
         divFlyghtseatcharfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divFlyghtseatlocationfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divFlyghtseatidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Seat";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cFlyghtSeatId","fld":"vCFLYGHTSEATID","pic":"ZZZ9"},{"av":"cmbavCflyghtseatlocation"},{"av":"AV7cFlyghtSeatLocation","fld":"vCFLYGHTSEATLOCATION"},{"av":"cmbavCflyghtseatchar"},{"av":"AV8cFlyghtSeatChar","fld":"vCFLYGHTSEATCHAR"},{"av":"AV9pFlyghtId","fld":"vPFLYGHTID","pic":"ZZZ9"}]}""");
         setEventMetadata("'TOGGLE'","""{"handler":"E140J1","iparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]""");
         setEventMetadata("'TOGGLE'",""","oparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]}""");
         setEventMetadata("LBLFLYGHTSEATIDFILTER.CLICK","""{"handler":"E110J1","iparms":[{"av":"divFlyghtseatidfiltercontainer_Class","ctrl":"FLYGHTSEATIDFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLFLYGHTSEATIDFILTER.CLICK",""","oparms":[{"av":"divFlyghtseatidfiltercontainer_Class","ctrl":"FLYGHTSEATIDFILTERCONTAINER","prop":"Class"},{"av":"edtavCflyghtseatid_Visible","ctrl":"vCFLYGHTSEATID","prop":"Visible"}]}""");
         setEventMetadata("LBLFLYGHTSEATLOCATIONFILTER.CLICK","""{"handler":"E120J1","iparms":[{"av":"divFlyghtseatlocationfiltercontainer_Class","ctrl":"FLYGHTSEATLOCATIONFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLFLYGHTSEATLOCATIONFILTER.CLICK",""","oparms":[{"av":"divFlyghtseatlocationfiltercontainer_Class","ctrl":"FLYGHTSEATLOCATIONFILTERCONTAINER","prop":"Class"},{"av":"cmbavCflyghtseatlocation"}]}""");
         setEventMetadata("LBLFLYGHTSEATCHARFILTER.CLICK","""{"handler":"E130J1","iparms":[{"av":"divFlyghtseatcharfiltercontainer_Class","ctrl":"FLYGHTSEATCHARFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLFLYGHTSEATCHARFILTER.CLICK",""","oparms":[{"av":"divFlyghtseatcharfiltercontainer_Class","ctrl":"FLYGHTSEATCHARFILTERCONTAINER","prop":"Class"},{"av":"cmbavCflyghtseatchar"}]}""");
         setEventMetadata("ENTER","""{"handler":"E170J2","iparms":[{"av":"A33FlyghtSeatId","fld":"FLYGHTSEATID","pic":"ZZZ9","hsh":true}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV10pFlyghtSeatId","fld":"vPFLYGHTSEATID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRID1_FIRSTPAGE","""{"handler":"subgrid1_firstpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cFlyghtSeatId","fld":"vCFLYGHTSEATID","pic":"ZZZ9"},{"av":"cmbavCflyghtseatlocation"},{"av":"AV7cFlyghtSeatLocation","fld":"vCFLYGHTSEATLOCATION"},{"av":"cmbavCflyghtseatchar"},{"av":"AV8cFlyghtSeatChar","fld":"vCFLYGHTSEATCHAR"},{"av":"AV9pFlyghtId","fld":"vPFLYGHTID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRID1_PREVPAGE","""{"handler":"subgrid1_previouspage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cFlyghtSeatId","fld":"vCFLYGHTSEATID","pic":"ZZZ9"},{"av":"cmbavCflyghtseatlocation"},{"av":"AV7cFlyghtSeatLocation","fld":"vCFLYGHTSEATLOCATION"},{"av":"cmbavCflyghtseatchar"},{"av":"AV8cFlyghtSeatChar","fld":"vCFLYGHTSEATCHAR"},{"av":"AV9pFlyghtId","fld":"vPFLYGHTID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRID1_NEXTPAGE","""{"handler":"subgrid1_nextpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cFlyghtSeatId","fld":"vCFLYGHTSEATID","pic":"ZZZ9"},{"av":"cmbavCflyghtseatlocation"},{"av":"AV7cFlyghtSeatLocation","fld":"vCFLYGHTSEATLOCATION"},{"av":"cmbavCflyghtseatchar"},{"av":"AV8cFlyghtSeatChar","fld":"vCFLYGHTSEATCHAR"},{"av":"AV9pFlyghtId","fld":"vPFLYGHTID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRID1_LASTPAGE","""{"handler":"subgrid1_lastpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cFlyghtSeatId","fld":"vCFLYGHTSEATID","pic":"ZZZ9"},{"av":"cmbavCflyghtseatlocation"},{"av":"AV7cFlyghtSeatLocation","fld":"vCFLYGHTSEATLOCATION"},{"av":"cmbavCflyghtseatchar"},{"av":"AV8cFlyghtSeatChar","fld":"vCFLYGHTSEATCHAR"},{"av":"AV9pFlyghtId","fld":"vPFLYGHTID","pic":"ZZZ9"}]}""");
         setEventMetadata("VALIDV_CFLYGHTSEATLOCATION","""{"handler":"Validv_Cflyghtseatlocation","iparms":[]}""");
         setEventMetadata("VALIDV_CFLYGHTSEATCHAR","""{"handler":"Validv_Cflyghtseatchar","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Flyghtid","iparms":[]}""");
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
         AV7cFlyghtSeatLocation = "";
         AV8cFlyghtSeatChar = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblflyghtseatidfilter_Jsonclick = "";
         TempTags = "";
         lblLblflyghtseatlocationfilter_Jsonclick = "";
         lblLblflyghtseatcharfilter_Jsonclick = "";
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
         AV12Linkselection_GXI = "";
         A34FlyghtSeatLocation = "";
         A35FlyghtSeatChar = "";
         lV7cFlyghtSeatLocation = "";
         lV8cFlyghtSeatChar = "";
         H000J2_A20FlyghtId = new short[1] ;
         H000J2_A35FlyghtSeatChar = new string[] {""} ;
         H000J2_A34FlyghtSeatLocation = new string[] {""} ;
         H000J2_A33FlyghtSeatId = new short[1] ;
         H000J3_AGRID1_nRecordCount = new long[1] ;
         AV11ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx00a1__default(),
            new Object[][] {
                new Object[] {
               H000J2_A20FlyghtId, H000J2_A35FlyghtSeatChar, H000J2_A34FlyghtSeatLocation, H000J2_A33FlyghtSeatId
               }
               , new Object[] {
               H000J3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV9pFlyghtId ;
      private short AV10pFlyghtSeatId ;
      private short wcpOAV9pFlyghtId ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV6cFlyghtSeatId ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A33FlyghtSeatId ;
      private short A20FlyghtId ;
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
      private int nRC_GXsfl_44 ;
      private int subGrid1_Rows ;
      private int nGXsfl_44_idx=1 ;
      private int edtavCflyghtseatid_Enabled ;
      private int edtavCflyghtseatid_Visible ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtFlyghtSeatId_Enabled ;
      private int edtFlyghtId_Enabled ;
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
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divFlyghtseatidfiltercontainer_Class ;
      private string divFlyghtseatlocationfiltercontainer_Class ;
      private string divFlyghtseatcharfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_44_idx="0001" ;
      private string AV7cFlyghtSeatLocation ;
      private string AV8cFlyghtSeatChar ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divFlyghtseatidfiltercontainer_Internalname ;
      private string lblLblflyghtseatidfilter_Internalname ;
      private string lblLblflyghtseatidfilter_Jsonclick ;
      private string edtavCflyghtseatid_Internalname ;
      private string TempTags ;
      private string edtavCflyghtseatid_Jsonclick ;
      private string divFlyghtseatlocationfiltercontainer_Internalname ;
      private string lblLblflyghtseatlocationfilter_Internalname ;
      private string lblLblflyghtseatlocationfilter_Jsonclick ;
      private string cmbavCflyghtseatlocation_Internalname ;
      private string cmbavCflyghtseatlocation_Jsonclick ;
      private string divFlyghtseatcharfiltercontainer_Internalname ;
      private string lblLblflyghtseatcharfilter_Internalname ;
      private string lblLblflyghtseatcharfilter_Jsonclick ;
      private string cmbavCflyghtseatchar_Internalname ;
      private string cmbavCflyghtseatchar_Jsonclick ;
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
      private string edtFlyghtSeatId_Internalname ;
      private string cmbFlyghtSeatLocation_Internalname ;
      private string A34FlyghtSeatLocation ;
      private string cmbFlyghtSeatChar_Internalname ;
      private string A35FlyghtSeatChar ;
      private string edtFlyghtId_Internalname ;
      private string lV7cFlyghtSeatLocation ;
      private string lV8cFlyghtSeatChar ;
      private string AV11ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_44_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtFlyghtSeatId_Jsonclick ;
      private string GXCCtl ;
      private string cmbFlyghtSeatLocation_Jsonclick ;
      private string cmbFlyghtSeatChar_Jsonclick ;
      private string edtFlyghtId_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_44_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV12Linkselection_GXI ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavCflyghtseatlocation ;
      private GXCombobox cmbavCflyghtseatchar ;
      private GXCombobox cmbFlyghtSeatLocation ;
      private GXCombobox cmbFlyghtSeatChar ;
      private IDataStoreProvider pr_default ;
      private short[] H000J2_A20FlyghtId ;
      private string[] H000J2_A35FlyghtSeatChar ;
      private string[] H000J2_A34FlyghtSeatLocation ;
      private short[] H000J2_A33FlyghtSeatId ;
      private long[] H000J3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short aP1_pFlyghtSeatId ;
   }

   public class gx00a1__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000J2( IGxContext context ,
                                             string AV7cFlyghtSeatLocation ,
                                             string AV8cFlyghtSeatChar ,
                                             string A34FlyghtSeatLocation ,
                                             string A35FlyghtSeatChar ,
                                             short AV9pFlyghtId ,
                                             short AV6cFlyghtSeatId ,
                                             short A20FlyghtId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[7];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [FlyghtId], [FlyghtSeatChar], [FlyghtSeatLocation], [FlyghtSeatId]";
         sFromString = " FROM [FlyghtSeat]";
         sOrderString = "";
         AddWhere(sWhereString, "([FlyghtId] = @AV9pFlyghtId and [FlyghtSeatId] >= @AV6cFlyghtSeatId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cFlyghtSeatLocation)) )
         {
            AddWhere(sWhereString, "([FlyghtSeatLocation] like @lV7cFlyghtSeatLocation)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cFlyghtSeatChar)) )
         {
            AddWhere(sWhereString, "([FlyghtSeatChar] like @lV8cFlyghtSeatChar)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         sOrderString += " ORDER BY [FlyghtId], [FlyghtSeatId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H000J3( IGxContext context ,
                                             string AV7cFlyghtSeatLocation ,
                                             string AV8cFlyghtSeatChar ,
                                             string A34FlyghtSeatLocation ,
                                             string A35FlyghtSeatChar ,
                                             short AV9pFlyghtId ,
                                             short AV6cFlyghtSeatId ,
                                             short A20FlyghtId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[4];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [FlyghtSeat]";
         AddWhere(sWhereString, "([FlyghtId] = @AV9pFlyghtId and [FlyghtSeatId] >= @AV6cFlyghtSeatId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cFlyghtSeatLocation)) )
         {
            AddWhere(sWhereString, "([FlyghtSeatLocation] like @lV7cFlyghtSeatLocation)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cFlyghtSeatChar)) )
         {
            AddWhere(sWhereString, "([FlyghtSeatChar] like @lV8cFlyghtSeatChar)");
         }
         else
         {
            GXv_int3[3] = 1;
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
                     return conditional_H000J2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] );
               case 1 :
                     return conditional_H000J3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] );
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
          Object[] prmH000J2;
          prmH000J2 = new Object[] {
          new ParDef("@AV9pFlyghtId",GXType.Int16,4,0) ,
          new ParDef("@AV6cFlyghtSeatId",GXType.Int16,4,0) ,
          new ParDef("@lV7cFlyghtSeatLocation",GXType.NChar,1,0) ,
          new ParDef("@lV8cFlyghtSeatChar",GXType.NChar,1,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000J3;
          prmH000J3 = new Object[] {
          new ParDef("@AV9pFlyghtId",GXType.Int16,4,0) ,
          new ParDef("@AV6cFlyghtSeatId",GXType.Int16,4,0) ,
          new ParDef("@lV7cFlyghtSeatLocation",GXType.NChar,1,0) ,
          new ParDef("@lV8cFlyghtSeatChar",GXType.NChar,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000J2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000J2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H000J3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000J3,1, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
