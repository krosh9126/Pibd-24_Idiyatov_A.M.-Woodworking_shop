namespace Woodworking_shop.Forms;

partial class FormMain
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        menuStrip = new MenuStrip();
        ReferenceBooksToolStripMenuItem = new ToolStripMenuItem();
        productsToolStripMenuItem = new ToolStripMenuItem();
        materialsToolStripMenuItem = new ToolStripMenuItem();
        OperationsToolStripMenuItem = new ToolStripMenuItem();
        ordersToolStripMenuItem = new ToolStripMenuItem();
        reservationsToolStripMenuItem = new ToolStripMenuItem();
        ReportsToolStripMenuItem = new ToolStripMenuItem();
        menuStrip.SuspendLayout();
        SuspendLayout();
        // 
        // menuStrip
        // 
        menuStrip.ImageScalingSize = new Size(24, 24);
        menuStrip.Items.AddRange(new ToolStripItem[] { ReferenceBooksToolStripMenuItem, OperationsToolStripMenuItem, ReportsToolStripMenuItem });
        menuStrip.Location = new Point(0, 0);
        menuStrip.Name = "menuStrip";
        menuStrip.Size = new Size(800, 33);
        menuStrip.TabIndex = 0;
        menuStrip.Text = "menuStrip1";
        // 
        // ReferenceBooksToolStripMenuItem
        // 
        ReferenceBooksToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { productsToolStripMenuItem, materialsToolStripMenuItem });
        ReferenceBooksToolStripMenuItem.Name = "ReferenceBooksToolStripMenuItem";
        ReferenceBooksToolStripMenuItem.Size = new Size(139, 29);
        ReferenceBooksToolStripMenuItem.Text = "Справочники";
        // 
        // productsToolStripMenuItem
        // 
        productsToolStripMenuItem.Name = "productsToolStripMenuItem";
        productsToolStripMenuItem.Size = new Size(270, 34);
        productsToolStripMenuItem.Text = "Изделия";
        productsToolStripMenuItem.Click += ProductsToolStripMenuItem_Click;
        // 
        // materialsToolStripMenuItem
        // 
        materialsToolStripMenuItem.Name = "materialsToolStripMenuItem";
        materialsToolStripMenuItem.Size = new Size(270, 34);
        materialsToolStripMenuItem.Text = "Материалы";
        materialsToolStripMenuItem.Click += MaterialsToolStripMenuItem_Click;
        // 
        // OperationsToolStripMenuItem
        // 
        OperationsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ordersToolStripMenuItem, reservationsToolStripMenuItem });
        OperationsToolStripMenuItem.Name = "OperationsToolStripMenuItem";
        OperationsToolStripMenuItem.Size = new Size(112, 29);
        OperationsToolStripMenuItem.Text = "Операции";
        // 
        // ordersToolStripMenuItem
        // 
        ordersToolStripMenuItem.Name = "ordersToolStripMenuItem";
        ordersToolStripMenuItem.Size = new Size(270, 34);
        ordersToolStripMenuItem.Text = "Заказы";
        ordersToolStripMenuItem.Click += OrdersToolStripMenuItem_Click;
        // 
        // reservationsToolStripMenuItem
        // 
        reservationsToolStripMenuItem.Name = "reservationsToolStripMenuItem";
        reservationsToolStripMenuItem.Size = new Size(270, 34);
        reservationsToolStripMenuItem.Text = "Резервы";
        reservationsToolStripMenuItem.Click += ReservationsToolStripMenuItem_Click;
        // 
        // ReportsToolStripMenuItem
        // 
        ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem";
        ReportsToolStripMenuItem.Size = new Size(88, 29);
        ReportsToolStripMenuItem.Text = "Отчёты";
        // 
        // FormMain
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        BackgroundImage = Properties.Resources.Wood;
        BackgroundImageLayout = ImageLayout.Stretch;
        ClientSize = new Size(800, 450);
        Controls.Add(menuStrip);
        MainMenuStrip = menuStrip;
        Name = "FormMain";
        Text = "Столярная мастерская";
        menuStrip.ResumeLayout(false);
        menuStrip.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private MenuStrip menuStrip;
    private ToolStripMenuItem ReferenceBooksToolStripMenuItem;
    private ToolStripMenuItem OperationsToolStripMenuItem;
    private ToolStripMenuItem ReportsToolStripMenuItem;
    private ToolStripMenuItem productsToolStripMenuItem;
    private ToolStripMenuItem materialsToolStripMenuItem;
    private ToolStripMenuItem ordersToolStripMenuItem;
    private ToolStripMenuItem reservationsToolStripMenuItem;
}
