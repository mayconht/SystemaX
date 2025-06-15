using Argon;


namespace ApiIntegrationTests;

public static class VerifySettings
{
    public static void Initialize()
    {
        VerifierSettings.AddExtraSettings(settings =>
        {
            settings.Formatting = Formatting.Indented;

        });
        VerifierSettings.AddScrubber(scrubber =>
        {

            // Scrub GUIDs
            scrubber.Replace(@"\b[a-fA-F0-9]{8}\b-[a-fA-F0-9]{4}\b-[a-fA-F0-9]{4}\b-[a-fA-F0-9]{4}\b-[a-fA-F0-9]{12}\b", "<scrubbed-guid>");

            // Scrub emails
            scrubber.Replace(@"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}\b", "<scrubbed-email>");
        });
    }
} 