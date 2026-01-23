using System.Windows.Forms;
using System.Drawing;

namespace ChatbotAI_Form
{
    public class ChatUIController
    {
        private Panel panelHeader;
        private FlowLayoutPanel flowActions;
        private FlowLayoutPanel flowMessages;
        private Panel panelBody;

        public ChatUIController(
            Panel header,
            FlowLayoutPanel actions,
            FlowLayoutPanel messages,
            Panel body)
        {
            panelHeader = header;
            flowActions = actions;
            flowMessages = messages;
            panelBody = body;
        }

        //  MÀN HÌNH CHÀO
        public void ShowWelcome()
        {
            panelHeader.Visible = true;
            flowActions.Visible = true;
            flowMessages.Visible = false;

            panelBody.Padding = new Padding(20);
        }

        //  ĐANG CHAT
        public void ShowChat()
        {
            panelHeader.Visible = false;
            flowActions.Visible = false;
            flowMessages.Visible = true;

            panelBody.Padding = new Padding(0);
        }
    }
}
