using GoFood.Domain.Google.Places.AutoComplete;

public record class Prediction(
    string description,
    List<MatchedSubstring> matched_substrings,
    string place_id,
    string reference,
    StructuredFormatting structured_formatting,
    List<Term> terms,
    List<string> types
);
