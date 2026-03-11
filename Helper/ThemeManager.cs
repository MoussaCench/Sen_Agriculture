using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AppSenAgriculture.Helper
{
    public static class ThemeManager
    {
        private static readonly Font FontNormal = new Font("Segoe UI", 9.5F, FontStyle.Regular);
        private static readonly Font FontInput = new Font("Segoe UI", 10F, FontStyle.Regular);
        private static readonly Font FontMenu = new Font("Segoe UI", 10F, FontStyle.Regular);
        private static readonly Font FontMenuSub = new Font("Segoe UI", 9.5F, FontStyle.Regular);
        private static readonly Font FontTitle = new Font("Segoe UI", 16F, FontStyle.Bold);
        private static readonly Font FontSubtitle = new Font("Segoe UI", 12F, FontStyle.Bold);
        private static readonly Font FontHeader = new Font("Segoe UI", 10F, FontStyle.Bold);
        private static readonly Font FontTitleBar = new Font("Segoe UI", 14F, FontStyle.Bold);
        private static readonly Font FontGridHeader = new Font("Segoe UI", 10F, FontStyle.Bold);
        private static readonly Font FontGridCell = new Font("Segoe UI", 9.5F, FontStyle.Regular);
        private static readonly Font FontButton = new Font("Segoe UI", 9.5F, FontStyle.Regular);
        public static readonly Color PrimaryColor = Color.FromArgb(25, 118, 210);
        public static readonly Color SecondaryColor = Color.FromArgb(21, 101, 192);
        public static readonly Color AccentColor = Color.FromArgb(66, 165, 245);
        public static readonly Color BackgroundColor = Color.FromArgb(245, 248, 252);
        public static readonly Color PanelColor = Color.White;
        public static readonly Color TextColor = Color.FromArgb(33, 33, 33);
        public static readonly Color BorderColor = Color.FromArgb(200, 210, 220);
        public static readonly Color HoverColor = Color.FromArgb(66, 165, 245);
        public static readonly Color ErrorColor = Color.FromArgb(229, 57, 53);
        public static readonly Color SuccessColor = Color.FromArgb(67, 160, 71);
        public static readonly Color WarningColor = Color.FromArgb(251, 140, 0);

        public static void Dispose()
        {
            FontNormal.Dispose();
            FontInput.Dispose();
            FontMenu.Dispose();
            FontMenuSub.Dispose();
            FontTitle.Dispose();
            FontSubtitle.Dispose();
            FontHeader.Dispose();
            FontTitleBar.Dispose();
            FontGridHeader.Dispose();
            FontGridCell.Dispose();
            FontButton.Dispose();
        }

        public static void ApplyMDITheme(Form form, MenuStrip menuStrip)
        {
            form.BackColor = BackgroundColor;
            form.ForeColor = TextColor;
            menuStrip.BackColor = PrimaryColor;
            menuStrip.ForeColor = Color.White;
            menuStrip.Font = FontMenu;
            menuStrip.Padding = new Padding(8, 5, 0, 5);
            menuStrip.Renderer = new ModernMenuRenderer();

            foreach (ToolStripMenuItem item in menuStrip.Items)
                StyleMenuItem(item);
        }

        private static void StyleMenuItem(ToolStripMenuItem menuItem)
        {
            menuItem.ForeColor = Color.White;
            menuItem.Font = FontMenu;

            if (menuItem.HasDropDownItems)
            {
                menuItem.DropDown.BackColor = PanelColor;
                menuItem.DropDown.ForeColor = TextColor;

                foreach (var item in menuItem.DropDownItems)
                {
                    if (item is ToolStripMenuItem subItem)
                    {
                        subItem.ForeColor = TextColor;
                        subItem.BackColor = PanelColor;
                        subItem.Font = FontMenuSub;
                        StyleMenuItem(subItem);
                    }
                }
            }
        }

        private class ModernMenuRenderer : ToolStripProfessionalRenderer
        {
            public ModernMenuRenderer() : base(new ModernMenuColorTable())
            {
            }

            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
                if (e.Item.Owner is MenuStrip)
                {
                    e.TextColor = Color.White;
                }
                else
                {
                    e.TextColor = TextColor;
                }
                base.OnRenderItemText(e);
            }
        }

        private class ModernMenuColorTable : ProfessionalColorTable
        {
            public override Color MenuItemSelected => HoverColor;
            public override Color MenuItemSelectedGradientBegin => HoverColor;
            public override Color MenuItemSelectedGradientEnd => HoverColor;
            public override Color MenuItemBorder => BorderColor;
            public override Color MenuBorder => BorderColor;
            public override Color MenuItemPressedGradientBegin => AccentColor;
            public override Color MenuItemPressedGradientEnd => AccentColor;
            public override Color ImageMarginGradientBegin => PanelColor;
            public override Color ImageMarginGradientMiddle => PanelColor;
            public override Color ImageMarginGradientEnd => PanelColor;
        }

        public static void ApplyFormTheme(Form form)
        {
            form.BackColor = BackgroundColor;
            form.ForeColor = TextColor;
            form.Font = FontNormal;
        }

        public static void StyleButton(Button button, ButtonType type = ButtonType.Primary)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.Font = FontButton;
            button.Cursor = Cursors.Hand;
            button.ForeColor = Color.White;
            button.Height = 40;
            button.Padding = new Padding(15, 0, 15, 0);

            switch (type)
            {
                case ButtonType.Primary:
                    button.BackColor = PrimaryColor;
                    button.FlatAppearance.BorderColor = SecondaryColor;
                    button.FlatAppearance.BorderSize = 0;
                    button.FlatAppearance.MouseOverBackColor = HoverColor;
                    break;
                case ButtonType.Secondary:
                    button.BackColor = SecondaryColor;
                    button.FlatAppearance.BorderSize = 0;
                    button.FlatAppearance.MouseOverBackColor = PrimaryColor;
                    break;
                case ButtonType.Danger:
                    button.BackColor = ErrorColor;
                    button.FlatAppearance.BorderSize = 0;
                    button.FlatAppearance.MouseOverBackColor = Color.FromArgb(211, 47, 47);
                    break;
                case ButtonType.Warning:
                    button.BackColor = WarningColor;
                    button.FlatAppearance.BorderSize = 0;
                    button.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 124, 0);
                    break;
                case ButtonType.Success:
                    button.BackColor = SuccessColor;
                    button.FlatAppearance.BorderSize = 0;
                    button.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 142, 60);
                    break;
            }
        }

        public static Panel CreateStyledPanel()
        {
            return new Panel
            {
                BackColor = PanelColor,
                Padding = new Padding(20)
            };
        }

        public static void StyleTextBox(TextBox textBox)
        {
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.Font = FontInput;
            textBox.Height = 30;
        }

        public static void StyleComboBox(ComboBox comboBox)
        {
            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.Font = FontInput;
            comboBox.BackColor = Color.White;
            comboBox.Height = 30;
        }

        public static void StyleLabel(Label label, LabelType type = LabelType.Normal)
        {
            switch (type)
            {
                case LabelType.Title:
                    label.Font = FontTitle;
                    label.ForeColor = PrimaryColor;
                    break;
                case LabelType.Subtitle:
                    label.Font = FontSubtitle;
                    label.ForeColor = SecondaryColor;
                    break;
                case LabelType.Header:
                    label.Font = FontHeader;
                    label.ForeColor = TextColor;
                    break;
                default:
                    label.Font = FontNormal;
                    label.ForeColor = TextColor;
                    break;
            }
        }

        public static void StyleDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.EnableHeadersVisualStyles = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = PrimaryColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = FontGridHeader;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = PrimaryColor;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
            dgv.ColumnHeadersHeight = 45;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = TextColor;
            dgv.DefaultCellStyle.Font = FontGridCell;
            dgv.DefaultCellStyle.SelectionBackColor = AccentColor;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Padding = new Padding(5);
            dgv.RowTemplate.Height = 35;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = AccentColor;
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White;

            dgv.GridColor = BorderColor;
        }

        public static Panel CreateTitleBar(string title)
        {
            Panel titleBar = new Panel
            {
                BackColor = PrimaryColor,
                Height = 50,
                Dock = DockStyle.Top
            };

            Label lblTitle = new Label
            {
                Text = title,
                ForeColor = Color.White,
                Font = FontTitleBar,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(20, 0, 0, 0)
            };

            titleBar.Controls.Add(lblTitle);
            return titleBar;
        }

        public static Panel CreateSeparator()
        {
            return new Panel
            {
                Height = 2,
                Dock = DockStyle.Top,
                BackColor = BorderColor
            };
        }

        public static void ApplyShadow(Control control)
        {
            control.Paint -= DrawShadow;
            control.Paint += DrawShadow;
        }

        private static void DrawShadow(object sender, PaintEventArgs e)
        {
            if (sender is Control control)
            {
                using (GraphicsPath path = new GraphicsPath())
                {
                    RectangleF rect = new RectangleF(0, 0, control.Width - 1, control.Height - 1);
                    path.AddRectangle(rect);
                    using (Pen pen = new Pen(Color.FromArgb(50, 0, 0, 0), 5))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            }
        }
    }

    public enum ButtonType
    {
        Primary,
        Secondary,
        Danger,
        Warning,
        Success
    }

    public enum LabelType
    {
        Normal,
        Title,
        Subtitle,
        Header
    }
}