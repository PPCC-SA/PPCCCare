<%@ Page Title="Knowledge Base" Language="vb" AutoEventWireup="false" MasterPageFile="~/Support.Master" CodeBehind="FAQ.aspx.vb" Inherits="Support.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
       h2.text-center {
            text-align: center;
            color: #00638c;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper">
         <div class="grid-form">
            <div class="row">
                <div class="form-horizontal">
                    <h2 class="text-center"><b>Knowledge Base</b></h2><br />
                    <div class="panel-group" id="accordion">
                      <div class="panel panel-default">
                        <div class="panel-heading">
                          <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion" href="#collapse1">
                            ถ้าจะทำการลดหนี้แต่เอกสารที่อ้างอิงได้มีการจ่ายชำระไปแล้ว สามารถทำได้ไหมคะ?</a>
                          </h4>
                        </div>
                        <div id="collapse1" class="panel-collapse collapse">
                          <div class="panel-body">ทำได้ค่ะ โดยไปที่หน้าจอ A/P Vouchers and Adjstments โดยฟิลด์ Type เลือกเป็น Adjustment 
                          และฟิลด์ Voucher ให้นำเลขที่ Voucher ที่ต้องการอ้างอิงมาใส่ ในส่วนของยอดเงินให้คีย์เป็นยอดติดลบ</div>
                        </div>
                      </div>
                      <div class="panel panel-default">
                        <div class="panel-heading">
                          <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion" href="#collapse2">
                            ถ้ามีการย้ายแผนกของทรัพย์สินต้องคำนวณค่าเสื่อมราคาก่อนหรือหลังย้ายคะ?</a>
                          </h4>
                        </div>
                        <div id="collapse2" class="panel-collapse collapse">
                          <div class="panel-body">ต้องทำการคำนวณค่าเสื่อมราคาก่อนแล้วค่อยทำการย้ายทรัพย์สิน</div>
                        </div>
                      </div>
                      <div class="panel panel-default">
                        <div class="panel-heading">
                          <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion" href="#collapse3">
                            ถ้าไม่มีหลักฐานการโอนจาก Warehouse ไป Production ซึ่งคุณวิทยาแนะนำให้ใช้ Multisite Quentity Move แต่างบัญชีไม่ยอมรับเนื่องจากหาเอกสารอ้างอิงไม่ได้ พอจะมีรายงานตัวไหนที่สามารถใช้ดูการ MOVE ได้บ้างครับ?</a>
                          </h4>
                        </div>
                        <div id="collapse3" class="panel-collapse collapse">
                          <div class="panel-body">สามารถดูข้อมูลการ MOVE ได้จาก Material Transitions Report โดยเลือก Type Stock Move และใส่ข้อมูลที่ Tab Inventory</div>
                        </div>
                      </div>
                      <div class="panel panel-default">
                        <div class="panel-heading">
                          <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion" href="#collapse4">
                            กำหนด Running Invoice ที่หน้าจอไหนคะ?</a>
                          </h4>
                        </div>
                        <div id="collapse4" class="panel-collapse collapse">
                          <div class="panel-body">Invoice Debit and Credit Memo Sequences</div>
                        </div>
                      </div>
                      <div class="panel panel-default">
                        <div class="panel-heading">
                          <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion" href="#collapse5">
                            กำหนด Prefix ของ Purchase Order และ Purchase Order Requisitions ที่หน้าจอไหนคะ?</a>
                          </h4>
                        </div>
                        <div id="collapse5" class="panel-collapse collapse">
                          <div class="panel-body">Purchasing Parameters ที่ Tap General ฟิลด์ PO Prefix และ PO Req Prefix</div>
                        </div>
                      </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
