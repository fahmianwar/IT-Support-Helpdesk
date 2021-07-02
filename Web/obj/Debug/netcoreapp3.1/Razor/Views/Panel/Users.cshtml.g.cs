#pragma checksum "D:\Github\IT Support Helpdesk\Web\Views\Panel\Users.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "11ac97db47eea2fa6ca76aec16ddca5405a280eb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Panel_Users), @"mvc.1.0.view", @"/Views/Panel/Users.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Github\IT Support Helpdesk\Web\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Github\IT Support Helpdesk\Web\Views\_ViewImports.cshtml"
using Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11ac97db47eea2fa6ca76aec16ddca5405a280eb", @"/Views/Panel/Users.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74b0619e1a302f0598271da1847e697c39d57b88", @"/Views/_ViewImports.cshtml")]
    public class Views_Panel_Users : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "5", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("needs-validation"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("formCreate"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("javascript:insertUser()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("javascript:editUser()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/usersList.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Github\IT Support Helpdesk\Web\Views\Panel\Users.cshtml"
  
    ViewData["Title"] = "List Users";
    Layout = "_PanelLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Content Wrapper. Contains page content -->
<div class=""content-wrapper"">
    <!-- Content Header (Page header) -->
    <section class=""content-header"">
        <div class=""container-fluid"">
            <div class=""row mb-2"">
                <div class=""col-sm-6"">
                    <h1>Users</h1>
                    <button type=""button"" class=""btn btn-success"" data-toggle=""modal"" data-target=""#createModal"">Create</button>
                </div>
                <div class=""col-sm-6"">
                    <ol class=""breadcrumb float-sm-right"">
                        <li class=""breadcrumb-item""><a href=""/Panel/"">Panel</a></li>
                        <li class=""breadcrumb-item active"">Users</li>
                    </ol>
                </div>
            </div>
        </div><!-- /.container-fluid -->
    </section>

    <!-- Main content -->
    <section class=""content"">
        <div class=""container-fluid"">
            <div class=""row"">
                <div class=""col-12"">
  ");
            WriteLiteral(@"                  <div class=""card"">
                        <div class=""card-header"">
                            <h3 class=""card-title"">List Users</h3>
                        </div>
                        <!-- /.card-header -->
                        <div class=""card-body"">
                            <table id=""tableUsers"" class=""table table-striped"">
                                <thead>
                                    <tr>
                                        <th>Id</th>
                                        <th>Name</th>
                                        <th>Email</th>
                                        <th>BirthDate</th>
                                        <th>Phone</th>
                                        <th>Address</th>
                                        <th>Department</th>
                                        <th>Company</th>
                                        <th>RoleName</th>
                                        <th>Action</th>
 ");
            WriteLiteral(@"                                   </tr>
                                </thead>
                            </table>
                        </div>
                        <!-- /.card-body -->
                    </div>
                    <!-- /.card -->
                </div>
                <!-- /.col -->
            </div>
            <!-- /.row -->
        </div>
        <!-- /.container-fluid -->
    </section>
    <!-- /.content -->
</div>
<!-- /.content-wrapper -->

<div id=""createModal"" class=""modal fade bd-example-modal-lg"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myLargeModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"">Create User</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
     ");
            WriteLiteral("       </div>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "11ac97db47eea2fa6ca76aec16ddca5405a280eb9365", async() => {
                WriteLiteral(@"
                <div class=""modal-body"">
                    <div class=""form-row"">
                        <div class=""col-md-4 mb-3"">
                            <label for=""inputCreateName"">Name</label>
                            <input type=""text"" class=""form-control"" id=""inputCreateName"" placeholder=""Name"" required>
                            <div class=""invalid-feedback"">
                                Please enter right string format.
                            </div>
                        </div>
                        <div class=""col-md-4 mb-3"">
                            <label for=""inputCreateEmail"">Email</label>
                            <input type=""email"" class=""form-control"" id=""inputCreateEmail"" placeholder=""Email"" required>
                            <div class=""invalid-feedback"">
                                Please enter right email format.
                            </div>
                        </div>
                        <div class=""col-md-4 mb-3"">
   ");
                WriteLiteral(@"                         <label for=""inputCreatePassword"">Password</label>
                            <input type=""password"" class=""form-control"" id=""inputCreatePassword"" placeholder=""Password"" required>
                            <div class=""invalid-feedback"">
                                Please enter right string format.
                            </div>
                        </div>
                    </div>
                    <div class=""form-row"">
                        <div class=""col-md-4 mb-3"">
                            <label for=""inputCreateBirthDate"">Birth Date</label>
                            <input type=""date"" class=""form-control"" id=""inputCreateBirthDate"" placeholder=""BirthDate"" required>
                            <div class=""invalid-feedback"">
                                Please enter right date format.
                            </div>
                        </div>
                        <div class=""col-md-4 mb-3"">
                            <label for=""");
                WriteLiteral(@"inputCreatePhone"">Phone</label>
                            <input type=""text"" class=""form-control"" id=""inputCreatePhone"" placeholder=""Phone"" required>
                            <div class=""invalid-feedback"">
                                Please enter right phone format.
                            </div>
                        </div>
                        <div class=""col-md-4 mb-3"">
                            <label for=""inputCreateRole"">Role</label>
                            <select class=""form-control"" id=""inputCreateRole"" placeholder=""Role"" required>
                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "11ac97db47eea2fa6ca76aec16ddca5405a280eb12438", async() => {
                    WriteLiteral("Admin");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "11ac97db47eea2fa6ca76aec16ddca5405a280eb13693", async() => {
                    WriteLiteral("Client");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                            </select>
                            <div class=""invalid-feedback"">
                                Please enter right role option.
                            </div>
                        </div>
                    </div>
                    <div class=""form-row"">
                        <div class=""col-md-12 mb-3"">
                            <label for=""inputCreateAddress"">Address</label>
                            <input type=""text"" class=""form-control"" id=""inputCreateAddress"" placeholder=""Address"" required>
                            <div class=""invalid-feedback"">
                                Please enter right address format.
                            </div>
                         </div>
                        </div>
                        <div class=""form-row"">
                            <div class=""col-md-6 mb-3"">
                                <label for=""inputCreateDepartment"">Department</label>
                                <input ty");
                WriteLiteral(@"pe=""text"" class=""form-control"" id=""inputCreateDepartment"" placeholder=""Department"" required>
                                <div class=""invalid-feedback"">
                                    Please enter right string format.
                                </div>
                            </div>
                            <div class=""col-md-6 mb-3"">
                                <label for=""inputCreateCompany"">Company</label>
                                <input type=""text"" class=""form-control"" id=""inputCreateCompany"" placeholder=""Company"" required>
                                <div class=""invalid-feedback"">
                                    Please enter right string format.
                                </div>
                            </div>
                        </div>
                    </div>
                <div class=""modal-footer"">
                    <button class=""btn btn-primary"">Create</button>
                </div>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("novalidate", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        </div>
    </div>
</div>

<div id=""editModal"" class=""modal fade bd-example-modal-lg"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myLargeModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"">Update</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "11ac97db47eea2fa6ca76aec16ddca5405a280eb19490", async() => {
                WriteLiteral(@"
                <div class=""modal-body"" id=""editModal"">
                    <div class=""form-row"">
                        <div class=""col-md-4 mb-3"">
                            <label for=""inputCreateName"">Name</label>
                            <input type=""text"" class=""form-control"" id=""inputCreateName"" placeholder=""Name"" required>
                            <div class=""invalid-feedback"">
                                Please enter right string format.
                            </div>
                        </div>
                        <div class=""col-md-4 mb-3"">
                            <label for=""inputCreateEmail"">Email</label>
                            <input type=""email"" class=""form-control"" id=""inputCreateEmail"" placeholder=""Email"" required>
                            <div class=""invalid-feedback"">
                                Please enter right email format.
                            </div>
                        </div>
                        <div class=""col-m");
                WriteLiteral(@"d-4 mb-3"">
                            <label for=""inputCreatePassword"">Password</label>
                            <input type=""password"" class=""form-control"" id=""inputCreatePassword"" placeholder=""Password"" required>
                            <div class=""invalid-feedback"">
                                Please enter right string format.
                            </div>
                        </div>
                    </div>
                    <div class=""form-row"">
                        <div class=""col-md-4 mb-3"">
                            <label for=""inputCreateBirthDate"">Birth Date</label>
                            <input type=""date"" class=""form-control"" id=""inputCreateBirthDate"" placeholder=""BirthDate"" required>
                            <div class=""invalid-feedback"">
                                Please enter right date format.
                            </div>
                        </div>
                        <div class=""col-md-4 mb-3"">
                         ");
                WriteLiteral(@"   <label for=""inputCreatePhone"">Phone</label>
                            <input type=""text"" class=""form-control"" id=""inputCreatePhone"" placeholder=""Phone"" required>
                            <div class=""invalid-feedback"">
                                Please enter right phone format.
                            </div>
                        </div>
                        <div class=""col-md-4 mb-3"">
                            <label for=""inputCreateRole"">Role</label>
                            <select class=""form-control"" id=""inputCreateRole"" placeholder=""Role"" required>
                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "11ac97db47eea2fa6ca76aec16ddca5405a280eb22581", async() => {
                    WriteLiteral("Admin");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "11ac97db47eea2fa6ca76aec16ddca5405a280eb23836", async() => {
                    WriteLiteral("Client");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                            </select>
                            <div class=""invalid-feedback"">
                                Please enter right role option.
                            </div>
                        </div>
                    </div>
                    <div class=""form-row"">
                        <div class=""col-md-12 mb-3"">
                            <label for=""inputCreateAddress"">Address</label>
                            <input type=""text"" class=""form-control"" id=""inputCreateAddress"" placeholder=""Address"" required>
                            <div class=""invalid-feedback"">
                                Please enter right address format.
                            </div>
                        </div>
                    </div>
                    <div class=""form-row"">
                        <div class=""col-md-6 mb-3"">
                            <label for=""inputCreateDepartment"">Department</label>
                            <input type=""text"" class=""form");
                WriteLiteral(@"-control"" id=""inputCreateDepartment"" placeholder=""Department"" required>
                            <div class=""invalid-feedback"">
                                Please enter right string format.
                            </div>
                        </div>
                        <div class=""col-md-6 mb-3"">
                            <label for=""inputCreateCompany"">Company</label>
                            <input type=""text"" class=""form-control"" id=""inputCreateCompany"" placeholder=""Company"" required>
                            <div class=""invalid-feedback"">
                                Please enter right string format.
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""modal-footer"">
                    <button class=""btn btn-primary"">Create</button>
                </div>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "11ac97db47eea2fa6ca76aec16ddca5405a280eb28607", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
#nullable restore
#line 256 "D:\Github\IT Support Helpdesk\Web\Views\Panel\Users.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
