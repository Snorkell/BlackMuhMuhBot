using System;
using System.Threading.Tasks;
using Discord.Commands;
using Discord;
using Discord.Audio;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using VideoLibrary;
using Discord.WebSocket;

namespace BotDiscordMultifunction.Modules
{
    public class AudioCOmmandsModule : ModuleBase <ICommandContext>
    {
        private static IAudioClient audioClient;
        private static List<string> Queue = new List<string>();
        static string pathMp4;
        static string pathMp3;
        static Stream output;
        static AudioOutStream discord;
        static int i = 0;
        [Command("addq", RunMode = RunMode.Async)]
        private async Task addToQueue([Remainder]string youtubeURL)
        {
            #region GetVideoInfos&Checkifthefilesexists
            var youTube = YouTube.Default; // starting point for YouTube actions
            var video = youTube.GetVideo(youtubeURL); // gets a Video object with info about the video
            pathMp3 = pathMp3 = (@"music\" + video.FullName + ".flac").Replace(" ", "").Replace("-YouTube.mp4", "").Replace("music\\","");
            DirectoryInfo d = new DirectoryInfo(@"music\");//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.flac");
            string str = "";
            foreach (FileInfo file in Files)
            {
                str = str + ", " + file.Name;
            }
#endregion
            //check if the music already exist in the sourve directory
            
            if(str.Contains(pathMp3))//If the string already exist -> do stuff
            {
                Queue.Add(@"music\" + pathMp3);
                await Context.Channel.SendMessageAsync($"Successfully added {pathMp3} to the queue");
            }
            else
            {
                DownloadVideo(youtubeURL);
                Queue.Add(pathMp3);
                await Context.Channel.SendMessageAsync($"Successfully added {pathMp3.Replace("music\\","")} to the queue");
            }
        }
        private Process CreateStream(string path)
        {
            var ffmpeg = new ProcessStartInfo
            {
                FileName = "ffmpeg",
                Arguments = $"-i {path} -ac 2 -f s16le -ar 48000 pipe:1",
                UseShellExecute = false,
                RedirectStandardOutput = true,
            };
            return Process.Start(ffmpeg);
        }
        [Command("play", RunMode = RunMode.Async)]
        private async Task SendAsync()
        {
            if(audioClient == null)
            {
                await Context.Channel.SendMessageAsync("Please make the bot join a channel first");
            }
            else
            {
                i = 0;
                while(i != Queue.Count)
                {
                    try
                    {
                        // Create FFmpeg using the previous example
                        var ffmpeg = CreateStream(Queue[i]);
                        output = ffmpeg.StandardOutput.BaseStream;
                        discord = audioClient.CreatePCMStream(AudioApplication.Mixed);
                        await Context.Channel.SendMessageAsync($"Now playing {Queue[i].Replace(@"music\", "").Replace(".flac", "")} in {Context.Channel.Name} ");
                        await (Context.Client as DiscordSocketClient).SetGameAsync(Queue[i].Replace(@"music\", "").Replace(".flac", ""));
                        await output.CopyToAsync(discord);
                        await discord.FlushAsync();
                    }catch
                    {
                        i++;
                        await Task.Delay(2000);
                        continue;
                    }
                    i++;
                }
                Queue.Clear();
            }
        }

        [Command("playrandom", RunMode = RunMode.Async)]
        private async Task RandomQueue(IVoiceChannel channel = null)
        {
            Queue.Clear();
            try
            {
                // Get the audio channel
                channel = channel ?? (Context.Message.Author as IGuildUser)?.VoiceChannel;
                if (channel == null) { await Context.Channel.SendMessageAsync("User must be in a voice channel, or a voice channel must be passed as an argument."); return; }

                // For the next step with transmitting audio, you would want to pass this Audio Client in to a service.
                audioClient = await channel.ConnectAsync();
            }
            catch (Exception e)
            {
                await Context.Channel.SendMessageAsync(e.Message);
            }
            List<int> RandomIndex = new List<int>();
            DirectoryInfo d = new DirectoryInfo(@"music\");//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.flac");
            foreach (FileInfo file in Files)
            {
                Queue.Add(file.Name);
            }
            foreach( int j in UniqueRandom(0, Queue.Count-1))
            {
                RandomIndex.Add(j);
            }
            i = 0;
            while (i != Queue.Count)
            {
                try
                {
                    // Create FFmpeg using the previous example
                    var ffmpeg = CreateStream(@"music\\"+ Queue[RandomIndex[i]]);
                    output = ffmpeg.StandardOutput.BaseStream;
                    discord = audioClient.CreatePCMStream(AudioApplication.Mixed);
                    await Context.Channel.SendMessageAsync($"Now playing {Queue[RandomIndex[i]].Replace(@"music\", "").Replace(".flac", "")} in {Context.Channel.Name} ");
                    await (Context.Client as DiscordSocketClient).SetGameAsync(Queue[RandomIndex[i]].Replace(@"music\", "").Replace(".flac", ""));
                    await output.CopyToAsync(discord);
                    await discord.FlushAsync();
                }
                catch
                {
                    i++;
                    await Task.Delay(2000);
                    continue;
                }
                i++;
            }
            Queue.Clear();
        }

        private static void DownloadVideo(string url)
        {
            try
            {
                var youTube = YouTube.Default; // starting point for YouTube actions
                var video = youTube.GetVideo(url); // gets a Video object with info about the video
                pathMp4 = (@"music\" + video.FullName);
                pathMp3 = (@"music\" + video.Title + ".flac").Replace(" ", "").Replace("-YouTube", "");
                File.WriteAllBytes(@"music\" + video.FullName, video.GetBytes());
                ToFlacFormat(pathMp4, pathMp3);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
        public static EventHandler ToFlacFormat(string pathToMp4, string pathToFlac)
        {
            var ffmpeg2 = new Process
            {
                StartInfo = { UseShellExecute = false, RedirectStandardError = true, FileName = "ffmpeg.exe" }
            };
            var arguments =
                String.Format(
                    @"-i ""{0}"" -c:a flac ""{1}""",
                    pathToMp4, pathToFlac);
            ffmpeg2.StartInfo.Arguments = arguments;
            try
            {
                if (!ffmpeg2.Start())
                {
                    Console.WriteLine("Error starting");
                }
                var reader = ffmpeg2.StandardError;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Debug.WriteLine(line);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
            }
            ffmpeg2.Close();
            File.Delete(pathToMp4);
            return null;
        }
        private static string RemoveIllegalPathCharacters(string path)
        {

            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            var r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            return r.Replace(path, "");
        }
        [Command("join", RunMode = RunMode.Async)]
        public async Task JoinChannel(IVoiceChannel channel = null)
        {
            try
            {
                // Get the audio channel
                channel = channel ?? (Context.Message.Author as IGuildUser)?.VoiceChannel;
                if (channel == null) { await Context.Channel.SendMessageAsync("User must be in a voice channel, or a voice channel must be passed as an argument."); return; }

                // For the next step with transmitting audio, you would want to pass this Audio Client in to a service.
                audioClient = await channel.ConnectAsync();
            }
            catch(Exception e)
            {
                await Context.Channel.SendMessageAsync(e.Message);
            }
        }
        [Command("Leave", RunMode = RunMode.Async)]
        public async Task leave()
        {
            await audioClient.StopAsync();
        }
        [Command("showq",RunMode = RunMode.Async)]
        private async Task ShowQueue()
        {
            if(Queue.Count != 0)
            {
                string queueContent = null;
                foreach (string name in Queue)
                {
                    queueContent = queueContent + ", \n" + name;
                }
                await Context.Channel.SendMessageAsync($"The queue contains: { queueContent.Replace(@"music\", "").Replace(".flac", "")}");
            }
            else
            {
                await Context.Channel.SendMessageAsync("The queue is empty");
            }
            
        }
        [Command("skip", RunMode = RunMode.Async)]
        private async Task Skip()
        {
            output.Close();
            if(Queue.Count!=0)
            {
                await Context.Channel.SendMessageAsync("Skipped to the next song");
            }
            else
            {
                await Context.Channel.SendMessageAsync("No more song on the queue");
            }
            
        }
        [Command("clearq", RunMode = RunMode.Async)]
        private async Task ClearQueue()
        {
            Queue.Clear();
            await Context.Channel.SendMessageAsync("Queue sucessfully cleared");
        }
        static IEnumerable<int> UniqueRandom(int minInclusive, int maxInclusive)
        {
            List<int> candidates = new List<int>();
            for (int i = minInclusive; i <= maxInclusive; i++)
            {
                candidates.Add(i);
            }
            Random rnd = new Random();
            while (candidates.Count > 0)
            {
                int index = rnd.Next(candidates.Count);
                yield return candidates[index];
                candidates.RemoveAt(index);
            }
        }
    }
}
