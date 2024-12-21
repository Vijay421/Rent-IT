import altair as alt
import pandas as pd

def get_burndown(data: pd.DataFrame) -> alt.JupyterChart:
    burndown_chart = alt.Chart(data) \
    .mark_line(point=alt.OverlayMarkDef(size=150, filled=True)) \
    .encode(
        x=alt.X(
            "sprint:O",
            axis=alt.Axis(labelAngle=0, grid=True),
            scale=alt.Scale(type='linear'),
        ).title("sprints"),
        y=alt.Y(
            "done:N",
            axis=alt.Axis(grid=True),
            scale=alt.Scale(type='linear'),
            ).title("user stories"),
        color=alt.Color("status:N"),
        tooltip=["sprint", "done", "status"],
    ) \
    .properties(
        width=400,
        height=500,
    ) \
    .interactive()

    labels = alt.Chart(data).mark_text(align="center", dy=-15, fontSize=12) \
    .encode(
        x="sprint:N",
        y="done:N",
        text="done:N"
    )

    return burndown_chart + labels

def get_sprint_data() -> pd.DataFrame:
    actual = [
        { "sprint": 1, "done": 0 },
        { "sprint": 2, "done": 0 },
        { "sprint": 3, "done": 0 },
        { "sprint": 4, "done": 0 },
        { "sprint": 5, "done": 1 },
        { "sprint": 6, "done": 10 },
    ]

    planned = [
        { "sprint": 1, "done": 2 },
        { "sprint": 2, "done": 3 },
        { "sprint": 3, "done": 5 },
        { "sprint": 4, "done": 6 },
        { "sprint": 5, "done": 8 },
        { "sprint": 6, "done": 12 },
    ]

    actual_df = pd.DataFrame(actual)
    planned_df = pd.DataFrame(planned)

    actual_df["status"] = "actual"
    planned_df["status"] = "planned"

    return pd.concat([actual_df, planned_df])


if __name__ == "__main__":
    sprint_data = get_sprint_data()
    burndown = get_burndown(sprint_data)
    burndown.save("burndown-chart.png")
