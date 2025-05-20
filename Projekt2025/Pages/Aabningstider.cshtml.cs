using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Projekt2025.Pages
{
    public class AabningstiderModel : PageModel
    {
        public string AdresseHtml { get; set; }
        public string AabningstiderHtml { get; set; }

        public void OnGet()
        {
            AdresseHtml = @"
                <h2>Roskilde</h2>
                <p>Magleg�rdsvej 2 2B</p>
                <p>4000 Roskilde</p>
                <p>tlf 12 34 56 78</p>
                <p><a href='https://www.google.com/maps/search/?api=1&query=Magleg�rdsvej+2+4000+Roskilde' target='_blank'>Find vej</a></p>
            ";

            AabningstiderHtml = @"
                <h3>�bningstider</h3>
                <table style='border-spacing: 0;'>
                    <tr><td>Mandag:</td><td style='padding-left: 10px;'>Lukket</td></tr>
                    <tr><td>Tirsdag:</td><td style='padding-left: 10px;'>Lukket</td></tr>
                    <tr><td>Onsdag:</td><td style='padding-left: 10px;'>Lukket</td></tr>
                    <tr><td>Torsdag:</td><td style='padding-left: 10px;'>Lukket</td></tr>
                    <tr><td>Fredag:</td><td style='padding-left: 10px;'>14-17</td></tr>
                    <tr><td>L�rdag:</td><td style='padding-left: 10px;'>Lukket</td></tr>
                    <tr><td>S�ndag:</td><td style='padding-left: 10px;'>Lukket</td></tr>
                </table>
            ";
        }
    }
}
