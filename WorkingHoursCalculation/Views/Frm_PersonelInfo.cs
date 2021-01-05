using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkingHoursCalculation.Helpers;
using WorkingHoursCalculation.Models;

namespace WorkingHoursCalculation.Views
{
    public partial class Frm_PersonelInfo : Form
    {
        /// <summary>
        /// 修改或者添加成功
        /// </summary>
        public bool updateORAddSuccess = false;
        /// <summary>
        /// 用户数据集
        /// </summary>
        DataTable userdt = new DataTable();

        /// <summary>
        /// 当前选中的记录的索引
        /// </summary>
        private string CurrentSelectNumber = string.Empty;
        public Frm_PersonelInfo()
        {
            InitializeComponent();

            //不显示未绑定数值的列
            this.datagridview.AutoGenerateColumns = false;

            //加载员工列表
            LoadPersonelInfo();

        }

        /// <summary>
        /// 加载所有有效的员工列表
        /// </summary>
        private void LoadPersonelInfo()
        {
            string sql = "Select * from Personnel where enable='1' order by ID;";
            userdt = DbHelperOleDb.Query(sql, new Dictionary<string, object>()).Tables[0];
            if (userdt != null && userdt.Rows.Count > 0)
            {
                datagridview.DataSource = userdt;
            }
            else
            {
                datagridview.DataSource = null;
            }
        }

        /// <summary>
        /// 双击查看详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            CurrentSelectNumber = string.Empty;
            try
            {
                if (this.datagridview.CurrentRow != null)
                {
                    string id = this.datagridview.CurrentRow.Cells["ID"].Value.ToString();
                    string name = this.datagridview.CurrentRow.Cells["name"].Value.ToString();
                    if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(name))
                    {
                        CurrentSelectNumber = this.datagridview.CurrentRow.Cells["ID"].Value.ToString();
                        DataRow[] dr = userdt.Select();
                        if (dr != null && dr.Length > 0)
                        {
                            txtName.Text = DESJiaMi.Decrypt(dr[0]["name"].ToString());
                            cboxGender.Text = DESJiaMi.Decrypt(dr[0]["gender"].ToString());
                            txtLxdh.Text = DESJiaMi.Decrypt(dr[0]["lxdh"].ToString());
                            richMainjob.Text = dr[0]["mainwork"].ToString();
                            labCreateTime.Text = dr[0]["createtime"].ToString();

                            //信息可编状态
                            IsAddNeiRong(false);

                            //重置按钮的初始状态
                            ResetBtnStrute();
                        }
                        else
                        {
                            ClearnNeiRong();
                        }
                    }
                    else
                    {
                        ClearnNeiRong();
                    }
                }
            }
            catch (Exception)
            {
                ClearnNeiRong();
            }
        }



        #region 按钮功能

        /// <summary>
        /// 更新信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (btn_Update.Text == "保 存")                                                                   //保存功能
            {
                if (!string.IsNullOrEmpty(txtName.Text.Trim()))
                {
                    //判断姓名是否重复
                    string sql = "Select * from Personnel where enable='1' and name='" + DESJiaMi.Encrypt(txtName.Text.Trim()) + "' and id<>" + CurrentSelectNumber + ";";
                    DataTable userUpdate = DbHelperOleDb.Query(sql, new Dictionary<string, object>()).Tables[0];
                    if (userUpdate != null && userUpdate.Rows.Count > 0)
                    {
                        MessageBox.Show("该姓名信息已经存在，不能重新添加该姓名的员工信息！！！", "保存", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        //执行更新
                        Personnel personnel = new Personnel();
                        personnel.name = DESJiaMi.Encrypt(txtName.Text.Trim());
                        personnel.gender = cboxGender.Text != "" ? DESJiaMi.Encrypt(cboxGender.Text.Trim()) : "";
                        personnel.lxdh = txtLxdh.Text != "" ? DESJiaMi.Encrypt(txtLxdh.Text.Trim()) : "";
                        personnel.mainwork = richMainjob.Text;
                        personnel.createtime = labCreateTime.Text;
                        personnel.createusername = UserInfo.userName;
                        personnel.enable = "1";
                        List<termList> termes = new List<termList>();
                        termes.Add(new termList("id", "id1", CurrentSelectNumber, 0));
                        if (DbHelperOleDb.Update(personnel, "Personnel", termes, null, true))
                        {
                             updateORAddSuccess = true;
                            MessageBox.Show("保存成功！", "修改", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //ClearnNeiRong();                        //清空内容
                            IsAddNeiRong(false);
                            SetButtonStatus(true, true, true);      //重置按钮状态
                            LoadPersonelInfo();                     //重新加载职工列表
                            btn_Update.Text = "修 改";
                        }
                        else
                        {
                            MessageBox.Show("保存失败！", "修改", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请先输入有效的“姓名”信息！！！", "保存", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(CurrentSelectNumber))        //修改功能
                {
                    //信息可编状态
                    IsAddNeiRong(true);

                    btn_Update.Text = "保 存";

                    //设置按钮状态
                    SetButtonStatus(true, false, false);
                }
                else
                {
                    MessageBox.Show("未选择有效的员工信息数据，无法进行修改。\r\n请先双击左侧待修改的员工列表中需要修改的记录", "修改", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(CurrentSelectNumber))
                {
                    if (MessageBox.Show("【注意】：\r\n删除该员工的信息之后，与该员工相关的工作信息也会被删除！\r\n是否继续删除？？？", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    {
                        return;
                    }

                    string sql = "update Personnel set enable = '2' where id =" + CurrentSelectNumber + ";";
                    int result = DbHelperOleDb.ExecuteSql(sql, new Dictionary<string, object>());
                    if (result > 0)
                    {
                        //重新加载员工列表
                        LoadPersonelInfo();

                        //清空左侧显示内容
                        ClearnNeiRong();

                         updateORAddSuccess = true;
                    }
                }
                else
                {
                    MessageBox.Show("未选择有效的员工信息数据，无法进行删除。\r\n请先双击左侧待修改的员工列表中需要删除的记录", "删除", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("删除操作失败！！！", "删除", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 新增信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (btn_Add.Text == "新 增")
            {
                //设置按钮状态
                SetButtonStatus(false, false, true);

                btn_Add.Text = "保 存";

                //清空数据
                ClearnNeiRong();
                //可编辑状态
                IsAddNeiRong(true);
                //创建时间
                labCreateTime.Text = DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss");
            }
            else  //(btn_Add.Text == "保存")
            {
                if (!string.IsNullOrEmpty(txtName.Text.Trim()))
                {
                    //判断姓名是否重复
                    string sql = "Select * from Personnel where enable='1' and name='" + DESJiaMi.Encrypt(txtName.Text.Trim()) + "';";
                    DataTable userUpdate = DbHelperOleDb.Query(sql, new Dictionary<string, object>()).Tables[0];
                    if (userUpdate != null && userUpdate.Rows.Count > 0)
                    {
                        MessageBox.Show("该姓名信息已经存在，不能重复添加！", "保存", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        //执行更新
                        Personnel personnel = new Personnel();
                        personnel.name = DESJiaMi.Encrypt(txtName.Text.Trim());
                        personnel.gender = cboxGender.Text != "" ? DESJiaMi.Encrypt(cboxGender.Text.Trim()) : "";
                        personnel.lxdh = txtLxdh.Text != "" ? DESJiaMi.Encrypt(txtLxdh.Text.Trim()) : "";
                        personnel.mainwork = richMainjob.Text;
                        personnel.createtime = labCreateTime.Text;
                        personnel.createusername = UserInfo.userName;
                        personnel.enable = "1";

                        if (DbHelperOleDb.Add(personnel, "Personnel", null))
                        {
                             updateORAddSuccess = true;
                            MessageBox.Show("保存成功！", "修改", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearnNeiRong();                        //清空内容
                            SetButtonStatus(true, true, true);      //重置按钮状态
                            LoadPersonelInfo();                     //重新加载职工列表
                            btn_Update.Text = "新 增";
                        }
                        else
                        {
                            MessageBox.Show("保存失败！", "修改", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请先输入有效的“姓名”信息！！！", "保存", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        #endregion


        /// <summary>
        /// 设置按钮的状态
        /// </summary>
        private void SetButtonStatus(bool isupdata, bool isdelete, bool isAdd)
        {
            btn_Update.Visible = isupdata;
            btn_Delete.Visible = isdelete;
            btn_Add.Visible = isAdd;
        }

        /// <summary>
        /// 清空数据
        /// </summary>
        private void ClearnNeiRong()
        {
            txtName.Text = cboxGender.Text = txtLxdh.Text = richMainjob.Text = labCreateTime.Text = "";
        }

        /// <summary>
        /// 重置按钮的状态 显示状态和可用状态
        /// </summary>
        private void ResetBtnStrute()
        {
            btn_Update.Text = "修 改";
            btn_Add.Text = "新 增";
            btn_Delete.Text = "删 除";

            //设置按钮状态
            SetButtonStatus(true, true, true);
        }

        /// <summary>
        /// 可编辑状态
        /// </summary>
        private void IsAddNeiRong(bool isStatus)
        {
            txtName.Enabled = cboxGender.Enabled = txtLxdh.Enabled = richMainjob.Enabled = isStatus;
        }

        /// <summary>
        /// 列内容转义
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void datagridview_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex != -1 && e.Value != null)
            {
                //获取列名
                string columnName = datagridview.Columns[e.ColumnIndex].Name;

                if ((columnName == "name") && e.Value.ToString() != "")
                {
                    e.Value = DESJiaMi.Decrypt(e.Value.ToString());
                }
            }
        }
    }
}
