using System.Collections.Generic;
using System.Threading.Tasks;
using YaR.MailRuCloud.Api.Base;

namespace YaR.MailRuCloud.Api.SpecialCommands
{
    public class DeleteCommand : SpecialCommand
    {
        public DeleteCommand(MailRuCloud cloud, string path, IList<string> parames): base(cloud, path, parames)
        {
        }

        protected override MinMax<int> MinMaxParamsCount { get; } = new MinMax<int>(0, 1);

        public override async Task<SpecialCommandResult> Execute()
        {
            string path;
            string param = Parames.Count == 0 ? string.Empty : Parames[0].Replace("\\", WebDavPath.Separator);

            if (Parames.Count == 0)
                path = Path;
            else if (param.StartsWith(WebDavPath.Separator))
                path = param;
            else
                path = WebDavPath.Combine(Path, param);

            var entry = await Cloud.GetItem(path);
            if (null == entry)
                return SpecialCommandResult.Fail;

            var res = await Cloud.Remove(entry);
            return new SpecialCommandResult { IsSuccess = res };
        }
    }


}