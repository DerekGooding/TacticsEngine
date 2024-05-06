using CaptainCoder.TacticsEngine.Board;

namespace WebEditor.Tools;
public sealed class FigureTool : Tool
{
    public static FigureTool Shared { get; } = new();
    private Positioned<Figure>? _selected;
    public Positioned<Figure>? Selected
    {
        get => _selected;
        set
        {
            if (_selected == value) { return; }
            var previous = _selected;
            _selected = value;
            OnChange?.Invoke(previous, _selected);
        }
    }

    public event Action<Positioned<Figure>?, Positioned<Figure>?>? OnChange;
}