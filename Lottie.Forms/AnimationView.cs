﻿using System;
using System.IO;
using System.Reflection;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lottie.Forms
{
    public class AnimationView : View
    {
        //public static readonly BindableProperty ImageProperty = BindableProperty.Create(nameof(Image),
        //    typeof(ImageSource), typeof(AnimationView), default(ImageSource));

        public static readonly BindableProperty AnimationProperty = BindableProperty.Create(nameof(Animation),
            typeof(object), typeof(AnimationView), default(object));

        public static readonly BindableProperty AnimationSourceProperty = BindableProperty.Create(nameof(Forms.AnimationSource),
            typeof(AnimationSource), typeof(AnimationView), default(AnimationSource));

        public static readonly BindableProperty CacheCompositionProperty = BindableProperty.Create(nameof(CacheComposition),
            typeof(bool), typeof(AnimationView), default(bool));

        public static readonly BindableProperty FallbackResourceProperty = BindableProperty.Create(nameof(FallbackResource),
            typeof(ImageSource), typeof(AnimationView), default(ImageSource));

        //public static readonly BindableProperty CompositionProperty = BindableProperty.Create(nameof(Composition),
        //    typeof(ILottieComposition), typeof(AnimationView), default(ILottieComposition));

        public static readonly BindableProperty MinFrameProperty = BindableProperty.Create(nameof(MinFrame),
            typeof(int), typeof(AnimationView), default(int));

        public static readonly BindableProperty MinProgressProperty = BindableProperty.Create(nameof(MinProgress),
            typeof(float), typeof(AnimationView), default(float));

        public static readonly BindableProperty MaxFrameProperty = BindableProperty.Create(nameof(MaxFrame),
            typeof(int), typeof(AnimationView), default(int));

        public static readonly BindableProperty MaxProgressProperty = BindableProperty.Create(nameof(MaxProgress),
            typeof(float), typeof(AnimationView), default(float));

        public static readonly BindableProperty SpeedProperty = BindableProperty.Create(nameof(Speed),
            typeof(float), typeof(AnimationView), 1.0f);

        public static readonly BindableProperty RepeatModeProperty = BindableProperty.Create(nameof(RepeatMode),
            typeof(RepeatMode), typeof(AnimationView), default(RepeatMode));

        public static readonly BindableProperty RepeatCountProperty = BindableProperty.Create(nameof(RepeatCount),
            typeof(int), typeof(AnimationView), default(int));

        public static readonly BindableProperty IsAnimatingProperty = BindableProperty.Create(nameof(IsAnimating),
            typeof(bool), typeof(AnimationView), default(bool));

        public static readonly BindableProperty ImageAssetsFolderProperty = BindableProperty.Create(nameof(ImageAssetsFolder),
            typeof(string), typeof(AnimationView), default(string));

        public static new readonly BindableProperty ScaleProperty = BindableProperty.Create(nameof(Scale),
        typeof(float), typeof(AnimationView), 1.0f);

        public static readonly BindableProperty FrameProperty = BindableProperty.Create(nameof(Frame),
        typeof(int), typeof(AnimationView), default(int));

        public static readonly BindableProperty ProgressProperty = BindableProperty.Create(nameof(Progress),
        typeof(float), typeof(AnimationView), 0.0f);

        //TODO: Maybe make TimeSpan
        public static readonly BindableProperty DurationProperty = BindableProperty.Create(nameof(Duration),
        typeof(long), typeof(AnimationView), default(long));

        public static readonly BindableProperty AutoPlayProperty = BindableProperty.Create(nameof(AutoPlay),
            typeof(bool), typeof(AnimationView), true);

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command),
            typeof(ICommand), typeof(AnimationView));

        public long Duration
        {
            get { return (long)GetValue(DurationProperty); }
            internal set { SetValue(DurationProperty, value); }
        }

        public bool CacheComposition
        {
            get { return (bool)GetValue(CacheCompositionProperty); }
            set { SetValue(CacheCompositionProperty, value); }
        }

        public object Animation
        {
            get { return (object)GetValue(AnimationProperty); }
            set { SetValue(AnimationProperty, value); }
        }

        public AnimationSource AnimationSource
        {
            get { return (AnimationSource)GetValue(AnimationSourceProperty); }
            set { SetValue(AnimationSourceProperty, value); }
        }

        public ImageSource FallbackResource
        {
            get { return (ImageSource)GetValue(FallbackResourceProperty); }
            set { SetValue(FallbackResourceProperty, value); }
        }

        //public ILottieComposition Composition
        //{
        //    get { return (ILottieComposition)GetValue(CompositionProperty); }
        //    set { SetValue(CompositionProperty, value); }
        //}

        public int MinFrame
        {
            get { return (int)GetValue(MinFrameProperty); }
            set { SetValue(MinFrameProperty, value); }
        }

        public float MinProgress
        {
            get { return (float)GetValue(MinProgressProperty); }
            set { SetValue(MinProgressProperty, value); }
        }

        public int MaxFrame
        {
            get { return (int)GetValue(MaxFrameProperty); }
            set { SetValue(MaxFrameProperty, value); }
        }

        public float MaxProgress
        {
            get { return (float)GetValue(MaxProgressProperty); }
            set { SetValue(MaxProgressProperty, value); }
        }

        public float Speed
        {
            get { return (float)GetValue(SpeedProperty); }
            set { SetValue(SpeedProperty, value); }
        }

        public RepeatMode RepeatMode
        {
            get { return (RepeatMode)GetValue(RepeatModeProperty); }
            set { SetValue(RepeatModeProperty, value); }
        }

        public int RepeatCount
        {
            get { return (int)GetValue(RepeatCountProperty); }
            set { SetValue(RepeatCountProperty, value); }
        }

        public bool IsAnimating
        {
            get { return (bool)GetValue(IsAnimatingProperty); }
            internal set { SetValue(IsAnimatingProperty, value); }
        }

        public string ImageAssetsFolder
        {
            get { return (string)GetValue(ImageAssetsFolderProperty); }
            set { SetValue(ImageAssetsFolderProperty, value); }
        }

        public new float Scale
        {
            get { return (float)GetValue(ScaleProperty); }
            set { SetValue(ScaleProperty, value); }
        }

        public int Frame
        {
            get { return (int)GetValue(FrameProperty); }
            set { SetValue(FrameProperty, value); }
        }

        public float Progress
        {
            get { return (float)GetValue(ProgressProperty); }
            set { SetValue(ProgressProperty, value); }
        }

        public bool AutoPlay
        {
            get { return (bool)GetValue(AutoPlayProperty); }
            set { SetValue(AutoPlayProperty, value); }
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public event EventHandler OnPlayAnimation;

        public event EventHandler OnPauseAnimation;

        public event EventHandler OnResumeAnimation;

        public event EventHandler OnStopAnimation;

        public event EventHandler OnRepeatAnimation;

        public event EventHandler Clicked;

        public event EventHandler<float> OnAnimationUpdate;

        public event EventHandler OnAnimator;

        public event EventHandler<object> OnAnimationLoaded;

        public event EventHandler<Exception> OnFailure;

        public event EventHandler OnEnded;

        internal void InvokePlayAnimation()
        {
            OnPlayAnimation?.Invoke(this, EventArgs.Empty);
        }

        internal void InvokeResumeAnimation()
        {
            OnResumeAnimation?.Invoke(this, EventArgs.Empty);
        }

        internal void InvokeStopAnimation()
        {
            OnStopAnimation?.Invoke(this, EventArgs.Empty);
        }

        internal void InvokePauseAnimation()
        {
            OnPauseAnimation?.Invoke(this, EventArgs.Empty);
        }

        internal void InvokeRepeatAnimation()
        {
            OnRepeatAnimation?.Invoke(this, EventArgs.Empty);
        }

        internal void InvokeAnimationUpdate(float progress)
        {
            OnAnimationUpdate?.Invoke(this, progress);
        }

        internal void InvokeAnimator()
        {
            OnAnimator?.Invoke(this, EventArgs.Empty);
        }

        internal void InvokeAnimationLoaded(object animation)
        {
            OnAnimationLoaded?.Invoke(this, animation);
        }

        internal void InvokeFailure(Exception ex)
        {
            OnFailure?.Invoke(this, ex);
        }

        internal void InvokePlaybackEnded()
        {
            OnEnded?.Invoke(this, EventArgs.Empty);
        }

        internal void InvokeClick()
        {
            Clicked?.Invoke(this, EventArgs.Empty);
            Command.ExecuteCommandIfPossible(this);
        }

        internal ICommand PlayCommand { get; set; }
        internal ICommand PauseCommand { get; set; }
        internal ICommand ResumeCommand { get; set; }
        internal ICommand StopCommand { get; set; }
        internal ICommand ClickCommand { get; set; }
        internal ICommand PlayMinAndMaxFrameCommand { get; set; }
        internal ICommand PlayMinAndMaxProgressCommand { get; set; }
        internal ICommand ReverseAnimationSpeedCommand { get; set; }

        public void Click()
        {
            ClickCommand.ExecuteCommandIfPossible(this);
        }

        public void PlayAnimation()
        {
            PlayCommand.ExecuteCommandIfPossible();
        }

        public void ResumeAnimation()
        {
            ResumeCommand.ExecuteCommandIfPossible();
        }

        public void StopAnimation()
        {
            StopCommand.ExecuteCommandIfPossible();
        }

        public void PauseAnimation()
        {
            PauseCommand.ExecuteCommandIfPossible();
        }

        public void PlayMinAndMaxFrame(int minFrame, int maxFrame)
        {
            PlayMinAndMaxFrameCommand.ExecuteCommandIfPossible((minFrame, maxFrame));
        }

        public void PlayMinAndMaxProgress(float minProgress, float maxProgress)
        {
            PlayMinAndMaxProgressCommand.ExecuteCommandIfPossible((minProgress, maxProgress));
        }

        public void ReverseAnimationSpeed()
        {
            ReverseAnimationSpeedCommand.ExecuteCommandIfPossible();
        }

        public void SetAnimationFromAssetOrBundle(string path)
        {
            AnimationSource = AnimationSource.AssetOrBundle;
            Animation = path;
        }

        public void SetAnimationFromEmbeddedResource(string resourceName, Assembly assembly = null)
        {
            AnimationSource = AnimationSource.EmbeddedResource;

            if(assembly == null)
                assembly = Xamarin.Forms.Application.Current.GetType().Assembly;

            var uri = $"resource://{resourceName}?assembly={Uri.EscapeUriString(assembly.FullName)}";
            Animation = uri;
        }

        public void SetAnimationFromJson(string json)
        {
            AnimationSource = AnimationSource.Json;
            Animation = json;
        }

        public void SetAnimationFromUrl(string url)
        {
            AnimationSource = AnimationSource.Url;
            Animation = url;
        }

        public void SetAnimationFromStream(Stream stream)
        {
            AnimationSource = AnimationSource.Stream;
            Animation = stream;
        }

        // setImageAssetDelegate(ImageAssetDelegate assetDelegate) {

        // setFontAssetDelegate(

        // setTextDelegate(TextDelegate textDelegate)

        // setScaleType

        //PerformanceTrackingEnabled

        //RenderMode
    }
}
